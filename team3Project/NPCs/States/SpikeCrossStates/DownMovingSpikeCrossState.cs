using System;

namespace LoZCloe
{
    public class DownMovingSpikeCrossState : IEnemyState
    {
        private SpikeCross spikeCross;
        private SpikeCrossSprite sprite;

        public DownMovingSpikeCrossState(SpikeCross spikeCross)
        {
            this.spikeCross = spikeCross;
            sprite = EnemySpriteFactory.Instance.createDownMovingSpikeCrossSprite();
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
            spikeCross.location = new Vector(spikeCross.location.X, spikeCross.location.Y + 3);
            sprite.update();
        }
    }
}
