using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class IdleSpikeCrossState : IEnemyState
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
            spikeCross.currentState = new LeftMovingSpikeCrossState(spikeCross);
        }
        public void moveRight()
        {
            spikeCross.currentState = new RightMovingSpikeCrossState(spikeCross);
        }
        public void moveUp()
        {
            spikeCross.currentState = new UpMovingSpikeCrossState(spikeCross);
        }
        public void moveDown()
        {
            spikeCross.currentState = new DownMovingSpikeCrossState(spikeCross);
        }
        public void stop()
        {
            // Blank b/c already moving down
        }

        public void takeDamage()
        {
 
        }
        public void die()
        {

        }

        public void update()
        {
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, spikeCross.currentLocation, Color.White);
        }
    }
}
