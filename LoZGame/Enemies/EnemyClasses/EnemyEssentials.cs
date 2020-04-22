namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public partial class EnemyEssentials
    {
        public virtual void UpdateState()
        {
            RandomStateGenerator.Update(this.States);
        }

        public virtual void UpdateChild()
        {
            // most enemies do not have any children
        }

        public virtual void AddChild()
        {
            // most enemies do not have any children
        }

        public virtual void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }

        public virtual void Attack()
        {
            // most enemies don't have special attack logic
        }

        public virtual void TakeDamage(int damageAmount)
        {
            if (this.DamageTimer <= 0 && !this.IsSpawning)
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
                if (this is Dragon || this is Dodongo || this is ManhandlaBody || this is GleeokBody)
                {
                    SoundFactory.Instance.PlayBossDie();
                    LoZGame.Instance.Drops.DropHeartContainer();
                }
                else
                {
                    SoundFactory.Instance.PlayEnemyDie();
                }
                this.IsDead = true;
                this.CurrentState.Die();
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
                    this.CurrentTint = LoZGame.Instance.DefaultTint;
                }
                this.Physics.HandleKnockBack();
            }
        }

        public virtual void Update()
        {
            this.HandleDamage();
            if (!LoZGame.Instance.Players[0].Inventory.HasClock || this.IsSpawning || this.IsDead)
            {
                this.CurrentState.Update();
                this.Physics.Move();
                this.Physics.SetDepth();
            }
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
            return EnemySpriteFactory.Instance.CreateOldManSprite();
        }
    }
}