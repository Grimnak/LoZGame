namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public abstract class PlayerEssentials
    {
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

        public void PickupItem(int itemTime)
        {
            this.State.PickupItem(itemTime);
        }

        public void UseItem(int waitTime)
        {
            this.State.UseItem(waitTime);
        }

        public abstract void Update();

        public abstract void Draw();

    }
}