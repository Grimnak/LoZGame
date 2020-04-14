namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public partial class Link
    {
        public IPlayerState State { get; set; }

        public LinkWeapon CurrentWeapon { get; set; }

        public LinkColor CurrentColor { get; set; }

        public Color CurrentTint { get; set; }

        public float MoveSpeed { get; set; }

        public int DamageTimer { get; set; }

        public Physics Physics { get; set; }

        public HealthManager Health { get; set; }

        public InventoryManager Inventory { get; set; }

        public void TakeDamage(int damageAmount)
        {
            if (this.DamageTimer <= 0)
            {
                if (!LoZGame.Cheats)
                {
                    this.Health.DamageHealth(damageAmount);
                }
                if (damageAmount > 0)
                {
                    SoundFactory.Instance.PlayLinkHurt();
                    this.DamageTimer = LoZGame.Instance.UpdateSpeed;
                }
            }
            if (this.Health.CurrentHealth <= 0)
            {
                SoundFactory.Instance.StopDungeonSong();
                SoundFactory.Instance.PlayLinkDie();
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
                    this.CurrentTint = LoZGame.Instance.DefaultTint;
                }
                this.Physics.HandleKnockBack();
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

        public void Stun(int stunTime)
        {
            this.State.Stun(stunTime);
        }

        public void Update()
        {
            this.Physics.SetDepth();
            this.HandleDamage();
            this.Physics.Move();
            this.State.Update();
        }

        public void Draw()
        {
            this.State.Draw();
        }
    }
}