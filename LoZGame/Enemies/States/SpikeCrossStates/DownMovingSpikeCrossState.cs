using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class DownMovingSpikeCrossState : IEnemyState
    {
        private SpikeCross spikeCross;
        private ISpikeCrossSprite sprite;

        public DownMovingSpikeCrossState(SpikeCross spikeCross)
        {
            this.spikeCross = spikeCross;
            sprite = EnemySpriteFactory.Instance.createDownMovingSpikeCrossSprite();
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
            // Blank b/c already moving down
        }
        public void stop()
        {
            spikeCross.currentState = new IdleSpikeCrossState(spikeCross);
        }

        public void takeDamage()
        {
 
        }
        public void die()
        {

        }

        public void update()
        {
            spikeCross.currentLocation = new Vector2(spikeCross.currentLocation.X, spikeCross.currentLocation.Y + 3);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, spikeCross.currentLocation, Color.White);
        }
    }
}
