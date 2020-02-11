using System;

namespace LoZCloe
{
    public class DownMovingSpikeCrossState : IEnemyState
    {
        private SpikeCrossState spikeCross;
        public DownMovingSpikeCrossState(SpikeCrossSprite spikeCrossSprite)
        {
            this.spikeCross = spikeCrossSprite;
            EnemySpriteFactory.Instance.createDownMovingSpikeCrossSprite();
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
            // Blank b/c already moving down
        }
        public void stop()
        {
            spikeCross.state = new IdleSpikeCrossState(spikeCross);
        }

        public void takeDamage()
        {
 
        }
        public void die()
        {

        }

        public void update()
        {
            spikeCross.moveDown();
            spikeCross.update();
        }
    }
}
