using System;

namespace LoZCloe
{
    public class LeftMovingSpikeCrossState : IEnemyState
    {
        private SpikeCrossState spikeCross;
        public LeftMovingSpikeCrossState(GoriyaSprite spikeCrossSprite)
        {
            this.spikeCross = spikeCrossSprite;
            EnemySpriteFactory.Instance.createDownMovingSpikeCrossSprite();
        }
        public void moveLeft()
        {
            // Blank b/c already moving down
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

        public void takeDamage()
        {
          
        }
        public void die()
        {

        }

        public void update()
        {
            spikeCross.moveLeft();
        }
    }
}
