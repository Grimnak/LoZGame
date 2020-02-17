using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class UpMovingSpikeCrossState : ISpikeCrossState
    {
        private SpikeCross spikeCross;
        private ISpikeCrossSprite sprite;

        public UpMovingSpikeCrossState(SpikeCross spikeCross)
        {
            this.spikeCross = spikeCross;
            sprite = EnemySpriteFactory.Instance.createSpikeCrossSprite();
        }
        public void moveLeft()
        {
            spikeCross.CurrentState = new LeftMovingSpikeCrossState(spikeCross);
        }
        public void moveRight()
        {
            spikeCross.CurrentState = new RightMovingSpikeCrossState(spikeCross);
        }
        public void moveUp()
        {
            // Blank b/c already moving down
        }
        public void moveDown()
        {
            
            spikeCross.CurrentState = new DownMovingSpikeCrossState(spikeCross);
        }
        public void stop()
        {
            spikeCross.CurrentState = new IdleSpikeCrossState(spikeCross);
        }

        public void Update()
        {
            spikeCross.currentLocation = new Vector2(spikeCross.currentLocation.X, spikeCross.currentLocation.Y - 3);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, spikeCross.currentLocation, Color.White);
        }
    }
}
