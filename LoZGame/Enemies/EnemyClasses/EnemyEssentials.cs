namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public abstract class EnemyEssentials
    {
        public Dictionary<RandomStateGenerator.StateType, int> States { get; set; }

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
                if (this is Dragon || this is Dodongo)
                {
                    SoundFactory.Instance.PlayDragonDie();
                    LoZGame.Instance.Drops.DropHeartContainer();
                    SoundFactory.Instance.PlayKeyAppears();
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
                    this.CurrentTint = LoZGame.Instance.DefaultTint;
                }
                this.Physics.HandleKnockBack();
            }
        }

        public virtual void Update()
        {
            this.HandleDamage();
            if (!LoZGame.Instance.Players[0].Inventory.HasClock || this.isDeathState())
            {
                this.CurrentState.Update();
                this.Physics.Move();
            }

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

        public abstract ISprite CreateCorrectSprite();

        private bool isDeathState()
        {
            return this.CurrentState is DeadDodongoState ||
                this.CurrentState is DeadDragonState ||
                this.CurrentState is DeadFireSnakeState ||
                this.CurrentState is DeadGelState ||
                this.CurrentState is DeadGoriyaState ||
                this.CurrentState is DeadKeeseState ||
                this.CurrentState is DeadRopeState ||
                this.CurrentState is DeadStalfosState ||
                this.CurrentState is DeadWallMasterState ||
                this.CurrentState is DeadZolState;
        }
    }
}