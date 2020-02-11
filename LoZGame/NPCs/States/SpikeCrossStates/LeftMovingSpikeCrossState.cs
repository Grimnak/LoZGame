using System;

namespace LoZCloe
{
    public class LeftMovingSpikeCrossState : IEnemyState
    {
        private SpikeCross spikeCross;
        private SpikeCrossSprite sprite;

        public LeftMovingSpikeCrossState(SpikeCross spikeCross)
        {
            this.spikeCross = spikeCross;
            sprite = EnemySpriteFactory.Instance.createDownMovingSpikeCrossSprite();
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
            spikeCross.location = new Vector(spikeCross.location.X - 3, spikeCross.location.Y);
            sprite.update();
        }
    }
}
