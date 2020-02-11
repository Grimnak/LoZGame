using System;

namespace LoZCloe
{
    public class IdleSpikeCrossState : IEnemyState
    {
        private SpikeCross spikeCross;
        private SpikeCrossSprite sprite;

        public IdleSpikeCrossState(SpikeCross spikeCross)
        {
            this.spikeCross = spikeCross;
            sprite = EnemySpriteFactory.Instance.createIdleSpikeCrossSprite();
        }
        public void moveLeft()
        {
            spikeCross.state = new LeftMovingSpikeCrossState(spikeCross);
        }
        public void moveRight()
        {
            spikeCross.state = new RightMovingSpikeCrossState(spikeCross);
        }
        public void moveUp()
        {
            spikeCross.state = new UpMovingSpikeCrossState(spikeCross);
        }
        public void moveDown()
        {
            spikeCross.state = new DownMovingSpikeCrossState(spikeCross);
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
    }
}
