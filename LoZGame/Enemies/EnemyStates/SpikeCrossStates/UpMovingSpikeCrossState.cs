﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingSpikeCrossState : IEnemyState
    {
        private readonly SpikeCross spikeCross;
        private readonly IEnemySprite sprite;

        public UpMovingSpikeCrossState(SpikeCross spikeCross)
        {
            this.spikeCross = spikeCross;
            this.sprite = EnemySpriteFactory.Instance.CreateSpikeCrossSprite();
        }

        public void MoveLeft()
        {
            this.spikeCross.CurrentState = new LeftMovingSpikeCrossState(this.spikeCross);
        }

        public void MoveRight()
        {
            this.spikeCross.CurrentState = new RightMovingSpikeCrossState(this.spikeCross);
        }

        public void MoveUp()
        {
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
            this.spikeCross.CurrentLocation = new Vector2(this.spikeCross.CurrentLocation.X, this.spikeCross.CurrentLocation.Y - 3);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.spikeCross.CurrentLocation, Color.White);
        }
    }
}