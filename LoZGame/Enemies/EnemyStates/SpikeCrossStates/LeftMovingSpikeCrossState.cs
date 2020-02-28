﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LeftMovingSpikeCrossState : IEnemyState
    {
        private readonly SpikeCross spikeCross;
        private readonly IEnemySprite sprite;

        public LeftMovingSpikeCrossState(SpikeCross spikeCross)
        {
            this.spikeCross = spikeCross;
            this.spikeCross.VelocityX = -1;
            this.spikeCross.VelocityY = 0;
            this.sprite = EnemySpriteFactory.Instance.CreateSpikeCrossSprite();
            this.spikeCross.CurrentState = this;
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
            this.spikeCross.CurrentState = new RightMovingSpikeCrossState(this.spikeCross);
        }

        public void MoveUp()
        {
            this.spikeCross.CurrentState = new UpMovingSpikeCrossState(this.spikeCross);
        }

        public void MoveDown()
        {
            this.spikeCross.CurrentState = new DownMovingSpikeCrossState(this.spikeCross);
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

        public void TakeDamage()
        {
        }

        public void Die()
        {
        }

        public void Stop()
        {
            this.spikeCross.CurrentState = new IdleSpikeCrossState(this.spikeCross);
        }

        public void Update()
        {
            this.spikeCross.Physics.Location = new Vector2(this.spikeCross.Physics.Location.X + this.spikeCross.VelocityX, this.spikeCross.Physics.Location.Y + this.spikeCross.VelocityY);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.spikeCross.Physics.Location, Color.White);
        }
    }
}