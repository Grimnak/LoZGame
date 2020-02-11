using System;

namespace LoZCloe
{
    public class UpMovingSpikeCrossState : IEnemyState
    {
        private SpikeCross spikeCross;
        private SpikeCrossSprite sprite;

        public UpMovingSpikeCrossState(SpikeCross spikeCross)
        {
            this.spikeCross = spikeCross;
            sprite = EnemySpriteFactory.Instance.createUpMovingSpikeCrossSprite();
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
            spikeCross.location = new Vector(spikeCross.location.X, spikeCross.location.Y - 3);
            sprite.update();
        }
    }
}
