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
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.ManhandlaHeadHP);
            this.Physics = new Physics((neckBase + new Point(LoZGame.Instance.Random.Next(10, 30))).ToVector2());
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.DragonMass;
            this.Physics.IsMoveable = false;
            this.CurrentState = new IdleEnemyState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.DragonDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = 0;
            this.MinMaxWander = new Point(LoZGame.Instance.UpdateSpeed / 4, LoZGame.Instance.UpdateSpeed);
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.HasChild = true;
            this.AI = EnemyAI.GleeockHead;
            this.IsSpawning = false;
            this.ApplyDamageMod();
            this.ApplyLargeWeightModPos();
            this.ApplyLargeHealthMod();
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
            for (int i = 0; i < numNeckSegments; i++)
            {
                IEnemy neckSegment = new GleeokNeck(this);
                this.necksegments.Add(neckSegment);
                LoZGame.Instance.GameObjects.Enemies.Add(neckSegment);
            }
            this.SetNeckLocations();
        }

        private void CheckNeckReach()
        {
            if (Math.Abs(this.Physics.Bounds.Center.X - neckBase.X) > maxX)
            {
                if (this.Physics.Bounds.Center.X - neckBase.X > 0)
                {
                    this.Physics.Bounds = new Rectangle(new Point(this.neckBase.X + maxX - (this.Physics.Bounds.Width / 2), this.Physics.Bounds.Y), this.Physics.Bounds.Size);
                }
                else
                {
                    this.Physics.Bounds = new Rectangle(new Point(this.neckBase.X - maxX + (this.Physics.Bounds.Width / 2), this.Physics.Bounds.Y), this.Physics.Bounds.Size);
                }
            }
            if (this.Physics.Bounds.Center.Y - neckBase.Y > maxY)
            {
                this.Physics.Bounds = new Rectangle(new Point(this.Physics.Bounds.Center.X, this.neckBase.Y + maxY + (this.Physics.Bounds.Height / 2)), this.Physics.Bounds.Size);
            }
            else if (this.Physics.Bounds.Center.Y < neckBase.Y)
            {
                this.Physics.Bounds = new Rectangle(new Point(this.Physics.Bounds.Center.X, neckBase.Y - (this.Physics.Bounds.Height / 2)), this.Physics.Bounds.Size);
            }
        }

        private void SetNeckLocations()
        {
            Vector2 toBase = (this.Physics.Bounds.Center - neckBase).ToVector2();
            toBase /= numNeckSegments;
            Point offSet = new Point(necksegments[0].Physics.Bounds.Size.X / 2, necksegments[0].Physics.Bounds.Size.Y / 2);
            for (int i = 0; i < numNeckSegments; i++)
            {
                int xLoc = (int)(i * toBase.X) - offSet.X + LoZGame.Instance.Random.Next(-2, 2);
                int yLoc = (int)(i * toBase.Y) - offSet.Y + LoZGame.Instance.Random.Next(-2, 2); ;
                necksegments[i].Physics.Bounds = new Rectangle(new Point(xLoc, yLoc), necksegments[i].Physics.Bounds.Size);
                necksegments[i].Physics.Depth = this.Physics.Depth;
            }
        }

        public override void Update()
        {
            this.HandleDamage();
            if (!LoZGame.Instance.Players[0].Inventory.HasClock || this.IsSpawning || this.IsDead)
            {
                this.CheckNeckReach();
                this.SetNeckLocations();
                this.Physics.SetDepth();
                this.CurrentState.Update();
            }
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateGleeockHeadSprite();
        }
    }
}