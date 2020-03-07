namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public abstract class PlayerEssentials
    {
        public IPlayerState State { get; set; }

        public string CurrentWeapon { get; set; }

        public string CurrentColor { get; set; }

        public string CurrentDirection { get; set; }

        public Color CurrentTint { get; set; }

        public int MoveSpeed { get; set; }

        public int DamageTimer { get; set; }

        public Physics Physics { get; set; }

        public HealthManager Health { get; set; }

        public void TakeDamage(int damageAmount)
        {
            if (this.Health.CurrentHealth <= 0)
            {
                this.State.Die();
            }
            if (this.DamageTimer <= 0 && !(this.State is PickupItemState))
            {
                this.Health.DamageHealth(damageAmount);
                this.DamageTimer = 100;
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

        public abstract void Update();

        public abstract void Draw();

    }
}