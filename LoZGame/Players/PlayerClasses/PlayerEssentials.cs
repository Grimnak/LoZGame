namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public abstract class PlayerEssentials
    {
        public IPlayerState State { get; set; }

        public string CurrentWeapon { get; set; }

        public string CurrentColor { get; set; }

        public Color CurrentTint { get; set; }

        public float MoveSpeed { get; set; }

        public int DamageTimer { get; set; }

        public Physics Physics { get; set; }

        public HealthManager Health { get; set; }

        public InventoryManager Inventory { get; set; }

        public int AnimationSpeed { get; set; }

        public int FrameDelay { get; set; }

        public void TakeDamage(int damageAmount)
        {
            if (this.DamageTimer <= 0)
            {
                SoundEffectsFactory.Instance.PlayLinkHurt();
                this.Health.DamageHealth(damageAmount);
                this.DamageTimer = LoZGame.Instance.UpdateSpeed;
            }
            if (this.Health.CurrentHealth <= 0)
            {
                SoundEffectsFactory.Instance.PlayLinkDie();
                this.State.Die();
                LoZGame.Instance.GameState.Death();
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
                if (this.DamageTimer > (LoZGame.Instance.UpdateSpeed - (LoZGame.Instance.UpdateSpeed / (this.Physics.Mass * 2))))
                {
                    this.Physics.HandleKnockBack();
                }
            }
        }

        public void Idle()
        {
            this.State.Idle();
        }

        public void MoveUp()
        {
            this.State.MoveUp();
        }

        public void MoveDown()
        {
            this.State.MoveDown();
        }

        public void MoveLeft()
        {
            this.State.MoveLeft();
        }

        public void MoveRight()
        {
            this.State.MoveRight();
        }

        public void Attack()
        {
            this.State.Attack();
        }

        public void PickupItem(IItem item)
        {
            this.State.PickupItem(item);
        }

        public void UseItem(int waitTime)
        {
            this.State.UseItem(waitTime);
        }

    }
}