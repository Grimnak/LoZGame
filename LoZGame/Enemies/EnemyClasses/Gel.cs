﻿namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Gel : IEnemy
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

        public int MoveSpeed { get; set; }

        public Color CurrentTint { get; set; }

        public int Damage => damage;

        public int DamageTimer { get; set; }

        private IEnemyState currentState;
        private int damage = 1;
        private int health = 1;
        private int timeInIdle = 0;
        private int timeSinceIdle = 0;
        private int movementWaitMax = 100;
        private int movementWaitMin = 20;
        private int movementWait;
        private int idleWaitMin = 10;
        private int idleWaitMax = 40;
        private int idleWait;
        private RandomStateGenerator randomStateGenerator;
        private Random randomWaitGenerator;

        public Gel(Vector2 location)
        {
            this.Health = new HealthManager(health);
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Physics.Location = new Vector2(location.X, location.Y);
            this.ShouldMove = true;
            this.randomStateGenerator = new RandomStateGenerator(this, 2, 6);
            this.randomWaitGenerator = LoZGame.Instance.Random;
            this.movementWait = randomWaitGenerator.Next(movementWaitMin, movementWaitMax);
            this.idleWait = randomWaitGenerator.Next(idleWaitMin, idleWaitMax);
            this.CurrentState = new LeftMovingGelState(this);
            this.randomStateGenerator.Update();
            this.expired = false;
            this.DamageTimer = 0;
            this.MoveSpeed = 2;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        private void decideToMove()
        {
            if (ShouldMove)
            {
                if (timeSinceIdle++ > movementWait)
                {
                    movementWait = randomWaitGenerator.Next(movementWaitMin, movementWaitMax);
                    ShouldMove = !ShouldMove;
                    timeSinceIdle = 0;
                }
            }
            else
            {
                if (timeInIdle++ > idleWait)
                {
                    ShouldMove = !ShouldMove;
                    idleWait = randomWaitGenerator.Next(idleWaitMin, idleWaitMax);
                    timeInIdle = 0;
                    randomStateGenerator.Update();
                }
            }
        }

        public void TakeDamage(int damageAmount)
        {
            if (this.DamageTimer <= 0)
            {
                this.Health.DamageHealth(damageAmount);
                this.DamageTimer = 50;
            }
            if (this.Health.CurrentHealth <= 0)
            {
                this.currentState.Die();
            }
        }

        private void DamagePushback()
        {
            if (Math.Abs((int)this.Physics.Velocity.X) != 0 || Math.Abs((int)this.Physics.Velocity.Y) != 0)
            {
                this.Physics.Move();
                this.Physics.Accelerate();
            }
        }

        private void HandleDamage()
        {
            if (this.DamageTimer > 0 && this.Health.CurrentHealth > 0)
            {
                this.DamageTimer--;
                if (this.DamageTimer % 10 > 5)
                {
                    this.CurrentTint = Color.DarkSlateGray;
                }
                else
                {
                    this.CurrentTint = Color.White;
                }
                this.DamagePushback();
            }
        }

        public void Update()
        {
            this.HandleDamage();
            this.decideToMove();
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
