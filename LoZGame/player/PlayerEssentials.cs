namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public abstract class PlayerEssentials : IPlayer
    {
        public LoZGame Game
        {
            get; set;
        }

        public IPlayerState State
        {
            get; set;
        }

        public string CurrentWeapon
        {
            get; set;
        }

        public string CurrentColor
        {
            get; set;
        }

        public string CurrentDirection
        {
            get; set;
        }

        public Vector2 CurrentLocation
        {
            get; set;
        }


        public Color CurrentTint
        {
            get; set;
        }

        public int CurrentSpeed
        {
            get; set;
        }

        public int DamageCounter
        {
            get; set;
        }

        public int DamageTimer
        {
            get; set;
        }

        public bool IsDead
        {
            get; set;
        }

        private void HandleDamage()
        {
            if (this.DamageTimer > 0 && this.DamageCounter < 3)
            {
                this.DamageTimer--;
                if (this.DamageTimer % 10 > 5)
                {
                    this.CurrentTint = Color.DarkSlateGray;
                }
                else
                {
                    this.CurrentTint = Color.White;
                }
            }
        }

        // This handleBounds method will not remain here past Sprint 2.  This is a form of "collision handling" just so Link will stay in bounds.
        /*private void HandleBounds()
        {
            if (this.CurrentLocation.X + 30 > this.Game.GraphicsDevice.Viewport.Width)
            {
                this.CurrentLocation.X = this.Game.GraphicsDevice.Viewport.Width - 30;
            }
            else if (this.CurrentLocation.X < 0)
            {
                this.CurrentLocation.X = 0;
            }

            if (this.CurrentLocation.Y + 30 > this.Game.GraphicsDevice.Viewport.Height)
            {
                this.CurrentLocation.Y = this.Game.GraphicsDevice.Viewport.Height - 30;
            }
            else if (this.CurrentLocation.Y < 0)
            {
                this.CurrentLocation.Y = 0;
            }
        }*/

        public void TakeDamage()
        {
            if (this.DamageCounter >= 3)
            {
                this.State.Die();
            }

            if (this.DamageTimer <= 0)
            {
                this.DamageCounter++;
                this.DamageTimer = 100;
            }
        }

        public abstract void Idle();

        public abstract void MoveUp();

        public abstract void MoveDown();

        public abstract void MoveLeft();

        public abstract void MoveRight();

        public abstract void Attack();

        public abstract void PickupItem(int itemTime);

        public abstract void UseItem(int waitTime);

        public void Update()
        {
            this.HandleDamage();
            //this.HandleBounds();

            this.State.Update();
        }

        public void Draw()
        {
            this.State.Draw();
        }

    }
}