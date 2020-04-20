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
            this.neckBase = new Point(body.Physics.Bounds.Center.X, body.Physics.Bounds.Bottom);
            this.parent = body;
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.GleeockHeadStateList);
            this.Health = new HealthManager(3 * GameData.Instance.EnemyDamageConstants.FullHeart);
            this.Physics = new Physics(neckBase.ToVector2());
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.DragonMass;
            this.Physics.IsMoveable = false;
            this.CurrentState = new IdleEnemyState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.FullHeart + GameData.Instance.EnemyDamageConstants.HalfHeart;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.GleeokHeadSpeed;
            this.DamageTimer = 0;
            this.MinMaxWander = new Point(LoZGame.Instance.UpdateSpeed / 4, LoZGame.Instance.UpdateSpeed);
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.HasChild = false;
            this.AI = EnemyAI.GleeockHead;
            this.IsSpawning = false;
            this.ApplyDamageMod();
            this.ApplyLargeWeightModPos();
            this.ApplySmallHealthMod();
        }

        public override void Stun(int stunTime)
        {
        }

        public override void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            // ignore obstacles
        }

        public override void AddChild()
        {
            this.necksegments = new List<IEnemy>();
            this.maxY = 0;
            this.maxX = 0;
            for (int i = 0; i < numNeckSegments; i++)
            {
                IEnemy neckSegment = new GleeokNeck(this);
                this.necksegments.Add(neckSegment);
                LoZGame.Instance.GameObjects.Enemies.Add(neckSegment);
                maxX += neckSegment.Physics.Bounds.Width / 3;
                maxY += neckSegment.Physics.Bounds.Height / 3;
            }
            this.Physics.Bounds = new Rectangle(this.Physics.Bounds.Location + new Point(LoZGame.Instance.Random.Next(-maxX / 2, maxX / 2), LoZGame.Instance.Random.Next(maxY / 2)), this.Physics.Bounds.Size);
            this.SetNeckLocations();
        }

        private void CheckNeckReach()
        {
            if (Math.Abs(this.Physics.Bounds.Center.X - neckBase.X) > maxX)
            {
                this.Physics.MovementVelocity = new Vector2(-this.Physics.MovementVelocity.X, this.Physics.MovementVelocity.Y);
            }
            if (Math.Abs(this.Physics.Bounds.Center.Y - neckBase.Y) > maxY)
            {
                this.Physics.MovementVelocity = new Vector2(this.Physics.MovementVelocity.X, -this.Physics.MovementVelocity.Y);
            }
            else if (this.Physics.Bounds.Center.Y < neckBase.Y)
            {
                this.Physics.MovementVelocity = new Vector2(this.Physics.MovementVelocity.X, -this.Physics.MovementVelocity.Y);
            }
        }

        private void SetNeckLocations()
        {
            Vector2 toBase = (this.Physics.Bounds.Center - neckBase).ToVector2();
            toBase /= numNeckSegments;
            Point offSet = new Point(necksegments[0].Physics.Bounds.Size.X / 2, necksegments[0].Physics.Bounds.Size.Y / 2);
            for (int i = 0; i < numNeckSegments; i++)
            {
                int xLoc = neckBase.X + (int)(i * toBase.X) - offSet.X;
                int yLoc = neckBase.Y + (int)(i * toBase.Y) - offSet.Y;
                necksegments[i].Physics.Bounds = new Rectangle(new Point(xLoc, yLoc), necksegments[i].Physics.Bounds.Size);
                necksegments[i].Physics.SetLocation();
                necksegments[i].Physics.Depth = this.Physics.Depth - 0.00001f;
            }
        }

        public override void Update()
        {
            base.Update();
            this.CheckNeckReach();
            this.SetNeckLocations();
            if (LoZGame.Instance.Difficulty > 2 && this.IsDead && !this.HasChild)
            {
                this.HasChild = true;
                IEnemy headOff = new GleeokHeadOff(this.parent, this.Physics.Bounds.Location);
                LoZGame.Instance.GameObjects.Enemies.AddNew(headOff);
            }
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateGleeockHeadSprite();
        }
    }
}