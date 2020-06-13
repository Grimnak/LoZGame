namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public partial class EnemyEssentials
    {
        public virtual void UpdateState()
        {
            RandomStateGenerator.Update(States);
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
            CurrentState.Stun(stunTime);
        }

        public virtual void Attack()
        {
            // most enemies don't have special attack logic
        }

        public virtual void TakeDamage(int damageAmount)
        {
            if (DamageTimer <= 0 && !IsSpawning)
            {
                Health.DamageHealth(damageAmount);
                if (damageAmount > 0)
                {
                    SoundFactory.Instance.PlayEnemyHit();
                    DamageTimer = LoZGame.Instance.UpdateSpeed;
                }
            }
            if (Health.CurrentHealth <= 0)
            {
                if (this is Dragon || this is Dodongo || this is ManhandlaBody || this is GleeokBody || this is DigDogger || this is RedGohma || this is Ganon)
                {
                    SoundFactory.Instance.PlayBossDie();
                    LoZGame.Instance.Drops.DropHeartContainer();
                }
                else
                {
                    SoundFactory.Instance.PlayEnemyDie();
                }
                IsDead = true;
                CurrentState.Die();
            }
        }

        public virtual void HandleDamage()
        {
            if (DamageTimer > 0 && Health.CurrentHealth > 0)
            {
                DamageTimer--;
                if (DamageTimer % 10 > 5)
                {
                    CurrentTint = Color.DarkSlateGray;
                }
                else
                {
                    CurrentTint = Color.White;
                }
                Physics.HandleKnockBack();
            }
        }

        public virtual void Update()
        {
            // Ensure enemy colors correctly correspond with their room's current color tint and continue to adjust their colors accordingly.
            if (LoZGame.Instance.Dungeon.CurrentRoom.IsDark)
            {
                if (LoZGame.Instance.Dungeon.CurrentRoom.CurrentRoomTint == Color.Black)
                {
                    CurrentTint = Color.Black;
                }
                else if (LoZGame.Instance.Dungeon.CurrentRoom.CurrentRoomTint == LoZGame.Instance.DungeonTint)
                {
                    CurrentTint = Color.White;
                }
                else
                {
                    CurrentTint = LoZGame.Instance.DefaultTint;
                }
            }
            else
            {
                CurrentTint = Color.White;
            }

            HandleDamage();
            if (!LoZGame.Instance.Players[0].Inventory.HasClock || IsSpawning || IsDead)
            {
                CurrentState.Update();
                Physics.Move();
                Physics.SetDepth();
            }
        }

        public virtual void Draw()
        {
            if (!isInvisible)
            {
                CurrentState.Draw();
            }
        }

        public virtual void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                EnemyCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IBlock)
            {
                EnemyCollisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
            else if (otherCollider is IProjectile)
            {
                EnemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
        }

        public virtual void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            EnemyCollisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

        public virtual ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateOldManSprite();
        }
    }
}