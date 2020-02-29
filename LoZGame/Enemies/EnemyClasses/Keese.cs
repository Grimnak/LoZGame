﻿namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Keese : IEnemy
    {
        private EnemyCollisionHandler enemyCollisionHandler;
        private Rectangle bounds;

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        public Physics Physics { get; set; }

        public double VelocityX
        {
            get; set;
        }

        public double VelocityY
        {
            get; set;
        }

        public int AccelerationCurrent
        {
            get; set;
        }

        public int Health { get { return health; } set { health = value; } }

        private IEnemyState currentState;
        private int health = 10;
        private int lifeTime = 0;
        private int accelerationMax = 5;
        private readonly int directionChange = 40;
        private RandomStateGenerator randomStateGenerator;

        public Keese(Vector2 location)
        {
            this.Physics = new Physics(new Vector2(location.X, location.Y), new Vector2(0, 0), new Vector2(0, 0));
            this.currentState = new LeftMovingKeeseState(this);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, 20, 20);
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
            randomStateGenerator = new RandomStateGenerator(this, 2, 10);
        }

        private void updateAcceleration()
        {
            if (AccelerationCurrent++ > accelerationMax)
            {
                AccelerationCurrent = 0;
            }
        }


        public void TakeDamage()
        {
            this.currentState.TakeDamage();
        }

        public void Update()
        {
            this.lifeTime++;
            if (this.lifeTime > this.directionChange)
            {
                randomStateGenerator.Update();
                this.lifeTime = 0;
            }

            this.updateAcceleration();
            this.CurrentState.Update();
            this.bounds.X = (int)this.Physics.Location.X;
            this.bounds.Y = (int)this.Physics.Location.Y;
        }

        public void Draw()
        {
            this.currentState.Draw();
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IProjectile)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
        }

        public IEnemyState CurrentState
        {
            get { return this.currentState; }
            set { this.currentState = value; }
        }
    }
}
