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

        public void TakeDamage(int damageAmount)
        {
            if (this.DamageTimer <= 0)
            {
                this.Health.DamageHealth(damageAmount);
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
                    this.CurrentTint = LoZGame.Instance.DungeonTint;
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
            this.CheckRightBound();
            this.Physics.Move();
            this.State.Update();
        }

        public void Draw()
        {
            this.State.Draw();
        }

        /// <summary>
        /// Prevents the player from moving beyond the boss area while the boss is alive in the appropriate room.
        /// </summary>
        private void CheckRightBound()
        {
            int rightBound = BlockSpriteFactory.Instance.HorizontalOffset + (9 * BlockSpriteFactory.Instance.TileWidth) - this.Physics.Bounds.Width;
            if (LoZGame.Instance.Dungeon.CurrentRoomX == 4 && LoZGame.Instance.Dungeon.CurrentRoomY == 1)
            {
                if (LoZGame.Instance.GameObjects.Enemies.EnemyList.Count != 0 && this.Physics.Bounds.X > rightBound)
                {
                    this.Physics.Bounds = new Rectangle(new Point(rightBound, this.Physics.Bounds.Y), new Point(this.Physics.Bounds.Width, this.Physics.Bounds.Height));
                    this.Physics.MovementVelocity = Vector2.Zero;
                }
            }
        }
    }
}