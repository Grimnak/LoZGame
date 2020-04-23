namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ManhandlaHead : EnemyEssentials, IEnemy
    {
        private IEnemy parent;
        private Point parentOffset;
        private bool buffedParent;

        public ManhandlaHead(IEnemy body, Physics.Direction side)
        {
            parent = body;
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.ManhandlaHeadStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.ManhandlaHeadHealth);
            Physics = new Physics(body.Physics.Bounds.Center.ToVector2());
            Physics.Mass = GameData.Instance.EnemyMassConstants.DragonMass;
            Physics.IsMoveable = false;
            CurrentState = new IdleEnemyState(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            Physics.CurrentDirection = side;
            Setup();
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.DragonDamage;
            DamageTimer = 0;
            MoveSpeed = 0;
            CurrentTint = LoZGame.Instance.DefaultTint;
            HasChild = true;
            AI = EnemyAI.ManHandlaHead;
            IsSpawning = false;
            buffedParent = false;
            DropTable = GameData.Instance.EnemyDropTables.EmptyDropTable;
            ApplyDamageMod();
            ApplyLargeWeightModPos();
            ApplyLargeHealthMod();
        }

        private void Setup()
        {
            Point offset = new Point(Physics.Bounds.Size.X / 2, Physics.Bounds.Size.Y / 2);
            switch (Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    Physics.Bounds = new Rectangle(new Point(parent.Physics.Bounds.Center.X - offset.X, parent.Physics.Bounds.Top - Physics.Bounds.Height), Physics.Bounds.Size);
                    break;
                case Physics.Direction.South:
                    Physics.Bounds = new Rectangle(new Point(parent.Physics.Bounds.Center.X - offset.X, parent.Physics.Bounds.Bottom - 2), Physics.Bounds.Size);
                    break;
                case Physics.Direction.East:
                    Physics.Bounds = new Rectangle(new Point(parent.Physics.Bounds.Right, parent.Physics.Bounds.Center.Y - offset.Y), Physics.Bounds.Size);
                    break;
                default:
                    Physics.Bounds = new Rectangle(new Point(parent.Physics.Bounds.Left - Physics.Bounds.Width, parent.Physics.Bounds.Center.Y - offset.Y), Physics.Bounds.Size);
                    break;
            }
            Physics.SetLocation();
            parentOffset = Physics.Bounds.Location - parent.Physics.Bounds.Location;
        }

        public override void Stun(int stunTime)
        {
        }

        public override void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            // ignore obstacles
        }

        private void SetToSource()
        {
            Point currentOffset = Physics.Bounds.Location - parent.Physics.Bounds.Location;
            if (currentOffset != parentOffset)
            {
                Physics.Bounds = new Rectangle(parent.Physics.Bounds.Location + parentOffset, Physics.Bounds.Size);
                Physics.SetLocation();
            }
        }

        public override void Attack()
        {
            CurrentState = new AttackingManhandlaHeadState(this);
        }

        public override void Update()
        {
            HandleDamage();
            if (!LoZGame.Instance.Players[0].Inventory.HasClock || IsSpawning || IsDead)
            {
                SetToSource();
                Physics.SetDepth();
                CurrentState.Update();
            }
            if (IsDead && !buffedParent)
            {
                parent.MoveSpeed += LoZGame.Instance.Difficulty + 1;
                int minWander = parent.MinMaxWander.X - (LoZGame.Instance.UpdateSpeed * LoZGame.Instance.Difficulty / 8);
                int maxWander = parent.MinMaxWander.Y - (LoZGame.Instance.UpdateSpeed * LoZGame.Instance.Difficulty / 4);
                if (minWander < LoZGame.Instance.UpdateSpeed / 8)
                {
                    minWander = LoZGame.Instance.UpdateSpeed / 8;
                }
                if (maxWander < minWander)
                {
                    maxWander = minWander;
                }
                parent.MinMaxWander = new Point(minWander, maxWander);
                parent.UpdateState();
                buffedParent = true;
            }
        }

        public override ISprite CreateCorrectSprite()
        {
                return EnemySpriteFactory.Instance.CreateManhandlaHeadSprite(Physics.CurrentDirection);
        }
    }
}