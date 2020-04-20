namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class GleeokHeadOff : EnemyEssentials, IEnemy
    {
        private IEnemy parent;
        private Point parentOffset;
        private List<IEnemy> necksegments;
        private Point neckBase;
        private int maxX;
        private int maxY;

        public GleeokHeadOff(IEnemy body, Point spawnPoint)
        {
            this.parent = body;
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.GleeockHeadStateList);
            this.Health = new HealthManager(1);
            this.Physics = new Physics(spawnPoint.ToVector2());
            this.Physics.Mass = 1;
            this.Physics.IsMoveable = false;
            this.CurrentState = new IdleEnemyState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.IsTransparent = true;
            this.IsKillable = false;
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.FullHeart;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.FireSnakeSpeed;
            this.DamageTimer = 0;
            this.MinMaxWander = new Point(LoZGame.Instance.UpdateSpeed);
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.HasChild = false;
            this.AI = EnemyAI.GleeokHeadOff;
            this.IsSpawning = false;
            this.ApplyDamageMod();
            this.ApplyLargeSpeedMod();
        }

        public override void Stun(int stunTime)
        {
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public override void Update()
        {
            base.Update();
            this.Physics.Depth = 1;
            if (this.parent.IsDead)
            {
                this.IsDead = true;
                this.CurrentState.Die();
            }
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateGleeockHeadOffSprite();
        }
    }
}