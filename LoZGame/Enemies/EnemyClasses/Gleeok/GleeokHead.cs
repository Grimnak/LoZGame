namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class GleeokHead : EnemyEssentials, IEnemy
    {
        private IEnemy parent;
        private Point parentOffset;
        private List<IEnemy> necksegments;
        private int numNeckSegments = 5 + LoZGame.Instance.Difficulty;
        private Point neckBase;
        private int maxX;
        private int maxY;

        public GleeokHead(IEnemy body)
        {
            neckBase = new Point(body.Physics.Bounds.Center.X, body.Physics.Bounds.Bottom);
            parent = body;
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.GleeokHeadStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.GleeokHeadHealth);
            Physics = new Physics(neckBase.ToVector2());
            Physics.Mass = GameData.Instance.EnemyMassConstants.DragonMass;
            Physics.IsMovable = false;
            CurrentState = new IdleEnemyState(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.FullHeart + GameData.Instance.EnemyDamageConstants.HalfHeart;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.GleeokHeadSpeed;
            DamageTimer = 0;
            MinMaxWander = new Point(LoZGame.Instance.UpdateSpeed / 4, LoZGame.Instance.UpdateSpeed);
            CurrentTint = LoZGame.Instance.DefaultTint;
            IsBossPart = true;
            HasChild = false;
            AI = EnemyAI.GleeokHead;
            IsSpawning = false;
            DropTable = GameData.Instance.EnemyDropTables.EmptyDropTable;
            ApplyDamageMod();
            ApplyLargeWeightModPos();
            ApplySmallHealthMod();
        }

        public override void Stun(int stunTime)
        {
        }

        public override void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            // ignore obstacles
        }

        public override void TakeDamage(int damageAmount)
        {
            if (damageAmount >= Health.CurrentHealth && DamageTimer <= 0)
            {
                SpawnHeads();
            }
            base.TakeDamage(damageAmount);
        }

        private void SpawnHeads()
        {
            LoZGame.Instance.GameObjects.Enemies.Add(new GleeokHeadOff(parent, Physics.Bounds.Location));
            if (LoZGame.Instance.Difficulty > 2)
            {
                LoZGame.Instance.GameObjects.Enemies.Add(new GleeokHeadOff(parent, Physics.Bounds.Location));
            }
        }

        public override void AddChild()
        {
            necksegments = new List<IEnemy>();
            maxY = 0;
            maxX = 0;
            for (int i = 0; i < numNeckSegments; i++)
            {
                IEnemy neckSegment = new GleeokNeck(this);
                necksegments.Add(neckSegment);
                LoZGame.Instance.GameObjects.Enemies.Add(neckSegment);
                maxX += neckSegment.Physics.Bounds.Width / 3;
                maxY += neckSegment.Physics.Bounds.Height / 3;
            }
            Physics.Bounds = new Rectangle(Physics.Bounds.Location + new Point(LoZGame.Instance.Random.Next(-maxX / 2, maxX / 2), LoZGame.Instance.Random.Next(maxY / 2)), Physics.Bounds.Size);
            SetNeckLocations();
        }

        private void CheckNeckReach()
        {
            if (Math.Abs(Physics.Bounds.Center.X - neckBase.X) > maxX)
            {
                Physics.MovementVelocity = new Vector2(-Physics.MovementVelocity.X, Physics.MovementVelocity.Y);
            }
            if (Math.Abs(Physics.Bounds.Center.Y - neckBase.Y) > maxY)
            {
                Physics.MovementVelocity = new Vector2(Physics.MovementVelocity.X, -Physics.MovementVelocity.Y);
            }
            else if (Physics.Bounds.Center.Y < neckBase.Y)
            {
                Physics.MovementVelocity = new Vector2(Physics.MovementVelocity.X, -Physics.MovementVelocity.Y);
            }
        }

        private void SetNeckLocations()
        {
            Vector2 toBase = (Physics.Bounds.Center - neckBase).ToVector2();
            toBase /= numNeckSegments;
            Point offSet = new Point(necksegments[0].Physics.Bounds.Size.X / 2, necksegments[0].Physics.Bounds.Size.Y / 2);
            for (int i = 0; i < numNeckSegments; i++)
            {
                int xLoc = neckBase.X + (int)(i * toBase.X) - offSet.X;
                int yLoc = neckBase.Y + (int)(i * toBase.Y) - offSet.Y;
                necksegments[i].Physics.Bounds = new Rectangle(new Point(xLoc, yLoc), necksegments[i].Physics.Bounds.Size);
                necksegments[i].Physics.SetLocation();
                necksegments[i].Physics.Depth = Physics.Depth - 0.00001f;
            }
        }

        public override void Update()
        {
            base.Update();
            CheckNeckReach();
            SetNeckLocations();
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateGleeokHeadSprite();
        }
    }
}