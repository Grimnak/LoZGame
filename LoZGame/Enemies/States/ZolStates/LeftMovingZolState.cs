﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LeftMovingZolState : IEnemyState
    {
        private readonly Zol zol;
        private readonly IEnemySprite sprite;

        public LeftMovingZolState(Zol zol)
        {
            this.zol = zol;
            this.sprite = EnemySpriteFactory.Instance.CreateZolSprite();
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
            this.zol.CurrentState = new RightMovingZolState(this.zol);
        }

        public void MoveUp()
        {
            this.zol.CurrentState = new UpMovingZolState(this.zol);
        }

        public void MoveDown()
        {
            this.zol.CurrentState = new DownMovingZolState(this.zol);
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
            this.zol.Health--;
            if (this.zol.Health == 0)
            {
                this.zol.CurrentState.Die();
            }
        }

        public void Die()
        {
            this.zol.CurrentState = new DeadZolState(this.zol);
        }

        public void Update()
        {
            this.zol.CurrentLocation = new Vector2(this.zol.CurrentLocation.X - 1, this.zol.CurrentLocation.Y);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.zol.CurrentLocation, Color.White);
        }
    }
}