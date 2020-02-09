using System;

namespace LoZCloe
{
    public class RightMovingSpikeCrossState : IEnemyState
    {
        private SpikeCrossState spikeCross;
        public RightMovingSpikeCrossState(GoriyaSprite spikeCrossSprite)
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
            // Blank b/c already moving down
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
            spikeCross.moveRight();
        }
    }
}
