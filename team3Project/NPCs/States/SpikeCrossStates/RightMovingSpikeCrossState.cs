using System;

namespace LoZCloe
{
    public class RightMovingSpikeCrossState : IEnemyState
    {
        private SpikeCross spikeCross;
        private SpikeCrossSprite sprite;

        public RightMovingSpikeCrossState(SpikeCross spikeCross)
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
            spikeCross.location = new Vector(spikeCross.location.X + 3, spikeCross.location.Y);
            sprite.update();
        }
    }
}
