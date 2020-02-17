using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class IdleSpikeCrossState : ISpikeCrossState
    {
        private SpikeCross spikeCross;
        private ISpikeCrossSprite sprite;

        public IdleSpikeCrossState(SpikeCross spikeCross)
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
            spikeCross.CurrentState = new UpMovingSpikeCrossState(spikeCross);
        }
        public void moveDown()
        {
            spikeCross.CurrentState = new DownMovingSpikeCrossState(spikeCross);
        }
        public void stop()
        {
            // Blank b/c already moving down
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, spikeCross.currentLocation, Color.White);
        }
    }
}
