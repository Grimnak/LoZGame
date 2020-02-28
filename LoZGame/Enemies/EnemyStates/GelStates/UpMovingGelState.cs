﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingGelState : IEnemyState
    {
        private readonly Gel gel;
        private readonly IEnemySprite sprite;

        public UpMovingGelState(Gel gel)
        {
            this.gel = gel;
            this.gel.VelocityX = 0;
            this.gel.VelocityY = -1;
            this.sprite = EnemySpriteFactory.Instance.CreateGelSprite();
            this.gel.CurrentState = this;
        }

        public void MoveLeft()
        {
            this.gel.CurrentState = new LeftMovingGelState(this.gel);
        }

        public void MoveRight()
        {
            this.gel.CurrentState = new RightMovingGelState(this.gel);
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
            this.gel.CurrentState = new DownMovingGelState(this.gel);
        }

        public void MoveUpLeft()
        {
        }

        public void MoveUpRight()
        {
        }

        public void MoveDownLeft()
        {
        }

        public void MoveDownRight()
        {
        }

        public void Attack()
        {
        }

        public void Stop()
        {
        }

        public void TakeDamage()
        {
            this.gel.Health--;
            if (this.gel.Health == 0)
            {
                this.gel.CurrentState.Die();
            }
        }

        public void Die()
        {
            this.gel.CurrentState = new DeadGelState(this.gel);
        }

        public void Update()
        {
            if (this.gel.ShouldMove)
            {
                this.gel.CurrentLocation = new Vector2(this.gel.CurrentLocation.X + this.gel.VelocityX, this.gel.CurrentLocation.Y + this.gel.VelocityY);
            }
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.gel.CurrentLocation, Color.White);
        }
    }
}