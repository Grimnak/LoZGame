﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LeftMovingDodongoState : IEnemyState
    {
        private readonly Dodongo dodongo;
        private readonly IEnemySprite sprite;

        public LeftMovingDodongoState(Dodongo dodongo)
        {
            this.dodongo = dodongo;
            this.dodongo.VelocityX = -1;
            this.dodongo.VelocityY = 0;
            this.sprite = EnemySpriteFactory.Instance.CreateLeftMovingDodongoSprite();
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
            this.dodongo.CurrentState = new RightMovingDodongoState(this.dodongo);
        }

        public void MoveUp()
        {
            this.dodongo.CurrentState = new UpMovingDodongoState(this.dodongo);
        }

        public void MoveDown()
        {
            this.dodongo.CurrentState = new DownMovingDodongoState(this.dodongo);
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
            this.dodongo.Health--;
            if (this.dodongo.Health-- == 0)
            {
                this.dodongo.CurrentState.Die();
            }
        }

        public void Die()
        {
            this.dodongo.CurrentState = new DeadDodongoState(this.dodongo);
        }

        public void Update()
        {
            this.dodongo.Physics.Location = new Vector2(this.dodongo.Physics.Location.X + this.dodongo.VelocityX, this.dodongo.Physics.Location.Y + this.dodongo.VelocityY);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.dodongo.Physics.Location, Color.White);
        }
    }
}