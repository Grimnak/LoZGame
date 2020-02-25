namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RightMovingSpikeCrossState : IEnemyState
    {
        private readonly SpikeCross spikeCross;
        private readonly IEnemySprite sprite;

        public RightMovingSpikeCrossState(SpikeCross spikeCross)
        {
            this.spikeCross = spikeCross;
            this.spikeCross.VelocityX = 1;
            this.spikeCross.VelocityY = 0;
            this.sprite = EnemySpriteFactory.Instance.CreateSpikeCrossSprite();
        }

        public void MoveLeft()
        {
            this.spikeCross.CurrentState = new LeftMovingSpikeCrossState(this.spikeCross);
        }

        public void MoveRight()
        {
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
            this.spikeCross.CurrentLocation = new Vector2(this.spikeCross.CurrentLocation.X + this.spikeCross.VelocityX, this.spikeCross.CurrentLocation.Y + this.spikeCross.VelocityY);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.spikeCross.CurrentLocation, Color.White);
        }
    }
}