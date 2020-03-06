﻿namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Zol : IEnemy
    {
        private EnemyCollisionHandler enemyCollisionHandler;
        private Rectangle bounds;
        private bool expired;

        public bool Expired { get { return this.expired; } set { this.expired = value; } }

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        public Physics Physics { get; set; }

        public bool ShouldMove
        {
            get; set;
        }

        public HealthManager Health { get; set; }

        public int Damage => damage;

        private IEnemyState currentState;
        private int damage = 2;
        private int health = 4;
        private int timeSinceIdle = 0;
        private int timeInIdle = 0;
        private int movementWaitMax = 12;
        private RandomStateGenerator randomStateGenerator;

        public Zol(Vector2 location)
        {
            this.Health = new HealthManager(health);
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.currentState = new LeftMovingZolState(this);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
            this.ShouldMove = true;
            this.randomStateGenerator = new RandomStateGenerator(this, 2, 6);
            this.expired = false;
        }

        private void decideToMove()
        {
            if (ShouldMove)
            {
                if (timeSinceIdle++ > movementWaitMax)
                {
                    ShouldMove = !ShouldMove;
                    timeSinceIdle = 0;
                }
            }
            else
            {
                if (timeInIdle++ > movementWaitMax)
                {
                    ShouldMove = !ShouldMove;
                    timeInIdle = 0;
                    randomStateGenerator.Update();
                }
            }
        }

        public void TakeDamage(int damageAmount)
        {
            this.currentState.TakeDamage(damageAmount);
        }

        public void Update()
        {
            this.decideToMove();
            this.CurrentState.Update();
            this.bounds.X = (int)this.Physics.Location.X;
            this.bounds.Y = (int)this.Physics.Location.Y;
            if (this.Health.CurrentHealth <= 0)
            {
                this.CurrentState = new DeadZolState(this);
            }
        }

        public void Draw()
        {
            this.currentState.Draw();
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IBlock)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
            else if (otherCollider is IProjectile)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            enemyCollisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

        public IEnemyState CurrentState
        {
            get { return this.currentState; }
            set { this.currentState = value; }
        }
    }
}
