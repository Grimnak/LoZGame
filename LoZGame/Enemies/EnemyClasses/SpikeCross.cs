﻿namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SpikeCross : IEnemy
    {
        private EnemyCollisionHandler enemyCollisionHandler;
        private Rectangle bounds;
        private LoZGame Game;

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        public Physics Physics { get; set; }

        public HealthManager Health { get; set; }

        public int Damage => damage;

        public int AttackFactor
        {
            get; set;
        }

        public bool Attacking
        {
            get; set;
        }

        public bool Retreating
        {
            get; set;
        }

        private IEnemyState currentState;
        private int damage = 1;
        private int health = 1;
        private int lifeTime = 0;
        private readonly int directionChange = 40;

        public SpikeCross(Vector2 location)
        {
            this.Health = new HealthManager(health);
            this.Physics = new Physics(new Vector2(location.X, location.Y), new Vector2(0, 0), new Vector2(0, 0));
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, 25, 25);
            this.Game = LoZGame.Instance;
            this.currentState = new IdleSpikeCrossState(this);
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
            Attacking = false;
            Retreating = false;
        }

        private void updateLoc()
        {
            int spikeX = (int)Physics.Location.X;
            int spikeY = (int)Physics.Location.Y;
            int linkX = (int)Game.Link.Physics.Location.X;
            int linkY = (int)Game.Link.Physics.Location.Y;

            if (!Attacking)
            {
                if (spikeX == linkX)
                {
                    Attacking = true;
                    AttackFactor = 3 * (linkY - spikeY) / Math.Abs(linkY - spikeY);
                    currentState.MoveDown();
                }
                else if (spikeY == linkY)
                {
                    Attacking = true;
                    AttackFactor = 3 * (linkX - spikeX) / Math.Abs(linkX - spikeX);
                    currentState.MoveRight();
                }
            }
            this.currentState.Update();
        }

        public void TakeDamage(int damageAmount)
        {
        }

        public void Die()
        {
        }

        public void Update()
        {
            this.updateLoc();
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

        public IEnemyState CurrentState
        {
            get { return this.currentState; }
            set { this.currentState = value; }
        }
    }
}
