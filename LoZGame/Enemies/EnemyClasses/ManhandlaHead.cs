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
            this.parent = body;
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.ManhandlaHeadStateList);
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.ManhandlaHeadHealth);
            this.Physics = new Physics(body.Physics.Bounds.Center.ToVector2());
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.DragonMass;
            this.Physics.IsMoveable = false;
            this.CurrentState = new IdleEnemyState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.Physics.CurrentDirection = side;
            this.Setup();
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.DragonDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = 0;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.HasChild = true;
            this.AI = EnemyAI.NoSpawn;
            this.IsSpawning = false;
            this.buffedParent = false;
            this.ApplyDamageMod();
            this.ApplyLargeWeightModPos();
            this.ApplyLargeHealthMod();
        }

        private void Setup()
        {
            Point offset = new Point(this.Physics.Bounds.Size.X / 2, this.Physics.Bounds.Size.Y / 2);
            switch (this.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    this.Physics.Bounds = new Rectangle(new Point(this.parent.Physics.Bounds.Center.X - offset.X, this.parent.Physics.Bounds.Top - this.Physics.Bounds.Height), this.Physics.Bounds.Size);
                    break;
                case Physics.Direction.South:
                    this.Physics.Bounds = new Rectangle(new Point(this.parent.Physics.Bounds.Center.X - offset.X, this.parent.Physics.Bounds.Bottom - 2), this.Physics.Bounds.Size);
                    break;
                case Physics.Direction.East:
                    this.Physics.Bounds = new Rectangle(new Point(this.parent.Physics.Bounds.Right, this.parent.Physics.Bounds.Center.Y - offset.Y), this.Physics.Bounds.Size);
                    break;
                default:
                    this.Physics.Bounds = new Rectangle(new Point(this.parent.Physics.Bounds.Left - this.Physics.Bounds.Width, this.parent.Physics.Bounds.Center.Y - offset.Y), this.Physics.Bounds.Size);
                    break;
            }
            this.Physics.SetLocation();
            this.parentOffset = this.Physics.Bounds.Location - this.parent.Physics.Bounds.Location;
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
            Point currentOffset = this.Physics.Bounds.Location - this.parent.Physics.Bounds.Location;
            if (currentOffset != parentOffset)
            {
                this.Physics.Bounds = new Rectangle(this.parent.Physics.Bounds.Location + parentOffset, this.Physics.Bounds.Size);
                this.Physics.SetLocation();
            }
        }

        public override void Attack()
        {
            this.CurrentState = new AttackingManhandlaHeadState(this);
        }

        public override void Update()
        {
            this.HandleDamage();
            if (!LoZGame.Instance.Players[0].Inventory.HasClock || this.IsSpawning || this.IsDead)
            {
                this.SetToSource();
                this.Physics.SetDepth();
                this.CurrentState.Update();
            }
            if (this.IsDead && !this.buffedParent)
            {
                this.parent.MoveSpeed += LoZGame.Instance.Difficulty + 1;
                int minWander = this.parent.MinMaxWander.X - (LoZGame.Instance.UpdateSpeed * LoZGame.Instance.Difficulty / 8);
                int maxWander = this.parent.MinMaxWander.Y - (LoZGame.Instance.UpdateSpeed * LoZGame.Instance.Difficulty / 4);
                if (minWander < LoZGame.Instance.UpdateSpeed / 8)
                {
                    minWander = LoZGame.Instance.UpdateSpeed / 8;
                }
                if (maxWander < minWander)
                {
                    maxWander = minWander;
                }
                this.parent.MinMaxWander = new Point(minWander, maxWander);
                this.parent.UpdateState();
                this.buffedParent = true;
            }
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateManhandlaHeadSprite(this.Physics.CurrentDirection);
        }
    }
}