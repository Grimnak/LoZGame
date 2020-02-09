using System;

namespace LoZCloe
{
    public class UpMovingSpikeCrossState : IEnemyState
    {
        private SpikeCrossState spikeCross;
        public UpMovingSpikeCrossState(SpikeCrossSprite spikeCrossSprite)
        {
            this.spikeCross = spikeCrossSprite;
            EnemySpriteFactory.Instance.createUpMovingSpikeCrossSprite();
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
            // Blank b/c already moving down
        }
        public void moveDown()
        {
            
            spikeCross.state = new DownMovingSpikeCrossState(spikeCross);
        }

        public void takeDamage()
        {
          
        }
        public void die()
        {

        }

        public void update()
        {
            spikeCross.moveUp();
        }
    }
}
