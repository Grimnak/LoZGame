﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingDodongoState : IEnemyState
    {
        private readonly Dodongo dodongo;
        private readonly ISprite sprite;

        public UpMovingDodongoState(Dodongo dodongo)
        {
            this.dodongo = dodongo;
            this.sprite = EnemySpriteFactory.Instance.CreateUpMovingDodongoSprite();
            this.dodongo.CurrentState = this;
        }

        public void MoveLeft()
        {
            this.dodongo.CurrentState = new LeftMovingDodongoState(this.dodongo);
        }

        public void MoveRight()
        {
            this.dodongo.CurrentState = new RightMovingDodongoState(this.dodongo);
        }

        public void MoveUp()
        {
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

        public void Die()
        {
            this.dodongo.CurrentState = new DeadDodongoState(this.dodongo);
        }

        public void Update()
        {
            this.dodongo.Physics.Location = new Vector2(this.dodongo.Physics.Location.X, this.dodongo.Physics.Location.Y - this.dodongo.MoveSpeed);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.dodongo.Physics.Location, this.dodongo.CurrentTint);
        }
    }
}