﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;

    public class Dragon : EnemyEssentials, IEnemy
    {
        private const float FireballSpeed = 2.5f;
        private const float FireballSpread = MathHelper.PiOver4 / 2;
        private const int numberFireBalls = 3;
        public EntityManager EntityManager { get; set; }
        

        public Dragon(Vector2 location)
        {
            this.Health = new HealthManager(32);
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.EntityManager = LoZGame.Instance.GameObjects.Entities;
            this.CurrentState = new LeftMovingDragonState(this);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = 4;
            this.DamageTimer = 0;
            this.MoveSpeed = 1;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        public void ShootFireballs()
        {
            Vector2 playerVector = this.UnitVectorToPlayer(this.Physics.Location);
            Vector2 velocityVector = new Vector2(playerVector.X * FireballSpeed, playerVector.Y * FireballSpeed);
            for (int i = 0; i < numberFireBalls; i++)
            {
                float rotation = ((-1 * ((numberFireBalls - 1) / 2)) * FireballSpread) + (i * FireballSpread);
                Vector2 rotatedVelocity = this.RotateVector(velocityVector, rotation);
                Vector2 fireBallLocation = new Vector2(this.Physics.Location.X, this.Physics.Location.Y);
                Physics fireballPhysics = new Physics(fireBallLocation, rotatedVelocity, Vector2.Zero);
                EntityManager.EnemyProjectileManager.Add(EntityManager.EnemyProjectileManager.Fireball, fireballPhysics);
            }
        }

        public override void TakeDamage(int damageAmount)
        {
            if (this.DamageTimer <= 0)
            {
                this.Health.DamageHealth(damageAmount);
                this.DamageTimer = 100;
            }

            if (this.Health.CurrentHealth <= 0)
            {
                this.CurrentState.Die();
            }

            if (this.DamageTimer > 0 && this.Health.CurrentHealth > 0)
            {
                this.DamageTimer--;
                if (this.DamageTimer % 10 > 5)
                {
                    this.CurrentTint = Color.DarkSlateGray;
                }
                else
                {
                    this.CurrentTint = LoZGame.Instance.DungeonTint;
                }
            }
        }
    }
}