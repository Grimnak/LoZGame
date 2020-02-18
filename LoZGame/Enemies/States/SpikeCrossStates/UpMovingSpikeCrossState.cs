namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingSpikeCrossState : ISpikeCrossState
    {
        private readonly SpikeCross spikeCross;
        private readonly ISpikeCrossSprite sprite;

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
            // Blank b/c already moving down
        }

        public void MoveDown()
        {
            this.spikeCross.CurrentState = new DownMovingSpikeCrossState(this.spikeCross);
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