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

        public float MoveSpeed { get; set; }

        public int DamageTimer { get; set; }

        public Physics Physics { get; set; }

        public HealthManager Health { get; set; }

        public void TakeDamage(int damageAmount)
        {
            if (this.DamageTimer <= 0)
            {
                this.Health.DamageHealth(damageAmount);
                this.DamageTimer = 50;
            }
            if (this.Health.CurrentHealth <= 0)
            {
                this.State.Die();
            }
        }

        private void DamagePushback()
        {
            if (Math.Abs((int)this.Physics.Velocity.X) != 0 || Math.Abs((int)this.Physics.Velocity.Y) != 0)
            {
                this.Physics.Move();
                this.Physics.Accelerate();
            }
            else
            {
                this.Physics.StopMovement();
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
                this.DamagePushback();
            }
            else
            {
                this.Physics.StopMovement();
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