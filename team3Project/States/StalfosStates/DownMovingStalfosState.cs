using System;

namespace LoZCloe
{
    public class DownMovingStalfosState : IEnemyState
    {
        private StalfosSprite stalfos;
        public DownMovingStalfosState(StalfosSprite stalfosSprite)
        {
            this.stalfos = stalfosSprite;
            EnemySpriteFactory.Instance.createDownMovingStalfosSprite();
        }
        public void moveLeft()
        {
            stalfos.state = new LeftMovingStalfosState(stalfos);
        }
        public void moveRight()
        {
            stalfos.state = new RightMovingStalfosState(stalfos);
        }
        public void moveUp()
        {
            stalfos.state = new UpMovingStalfosState(stalfos);
        }
        public void moveDown()
        {
            // Blank b/c already moving down
        }

        public void takeDamage()
        {
            this.stalfos.health--;
            if (this.stalfos.health-- == 0)
            {
                stalfos.state.die();
            }
        }
        public void die()
        {

        }

        public void update()
        {
            stalfos.moveDown();
            stalfos.update();
        }
    }
}
