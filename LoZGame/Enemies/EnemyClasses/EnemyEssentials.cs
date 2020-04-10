﻿namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public abstract class EnemyEssentials
    {
        public EnemyCollisionHandler EnemyCollisionHandler { get; set; }

        public RandomStateGenerator RandomStateGenerator { get; set; }

        public IEnemyState CurrentState { get; set; }

        public bool Expired { get; set; }

        public Physics Physics { get; set; }

        public HealthManager Health { get; set; }

        public Color CurrentTint { get; set; }

        public float MoveSpeed { get; set; }

        public int Damage { get; set; }

        public int DamageTimer { get; set; }

        public virtual void Stun(int stunTime)
        {
        }

        public virtual void FacePlayer()
        {
        }

        public Vector2 UnitVectorToPlayer(Vector2 origin)
        {
            Vector2 unitVector = LoZGame.Instance.Link.Physics.Bounds.Center.ToVector2() - origin;
            unitVector.Normalize();
            return unitVector;
        }

        public Vector2 RotateVector(Vector2 oldVector, float rot)
        {
            float cosRot = (float)Math.Cos(rot);
            float sinRot = (float)Math.Sin(rot);
            float newX = (cosRot * oldVector.X) - (sinRot * oldVector.Y);
            float newY = (sinRot * oldVector.X) + (cosRot * oldVector.Y);
            return new Vector2(newX, newY);
        }

        public virtual void UpdateChild()
        {
            // most enemies do not have any children
        }

        public virtual void AddChild()
        {
            // most enemies dont have any children
        }

        public virtual void TakeDamage(int damageAmount)
        {
            if (this.DamageTimer <= 0)
            {
                this.Health.DamageHealth(damageAmount);
                if (damageAmount > 0)
                {
                    SoundFactory.Instance.PlayEnemyHit();
                    this.DamageTimer = LoZGame.Instance.UpdateSpeed;
                }
            }
            if (this.Health.CurrentHealth <= 0)
            {
                if (this is Dragon)
                {
                    SoundFactory.Instance.PlayDragonDie();
                }
                else
                {
                    SoundFactory.Instance.PlayEnemyDie();
                }
                this.CurrentState.Die();
                LoZGame.Instance.Drops.DropKey();
                LoZGame.Instance.Drops.DropBoomerang();
            }
        }

        public void HandleDamage()
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
                    this.CurrentTint = LoZGame.Instance.DungeonTint;
                }
                this.Physics.HandleKnockBack();
            }
        }

        public virtual void Update()
        {
            this.HandleDamage();
            this.CurrentState.Update();
            this.Physics.Move();
            this.Physics.SetDepth();
        }

        public virtual void Draw()
        {
            this.CurrentState.Draw();
        }

        public virtual void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.EnemyCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IBlock)
            {
                this.EnemyCollisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
            else if (otherCollider is IProjectile)
            {
                this.EnemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
        }

        public virtual void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            this.EnemyCollisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

        public virtual ISprite CreateCorrectSprite()
        {
            return ItemSpriteFactory.Instance.Fairy();
        }
    }
}