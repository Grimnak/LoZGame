using System;

namespace LoZCloe
{
    public class DownMovingGelState : IEnemyState
    {
        private GelSprite gel;
        public DownMovingGelState(GelSprite gelSprite)
        {
            this.gel = gelSprite;
            EnemySpriteFactory.Instance.createDownMovingGelSprite();
        }
        public void moveLeft()
        {
            gel.state = new LeftMovingGelState(gel);
        }
        public void moveRight()
        {
            gel.state = new RightMovingGelState(gel);
        }
        public void moveUp()
        {
            gel.state = new UpMovingGelState(gel);
        }
        public void moveDown()
        {
            // Blank b/c already moving down
        }

        public void takeDamage()
        {
            this.gel.health--;
            if (this.gel.health-- == 0)
            {
                gel.state.die();
            }
        }
        public void die()
        {

        }

        public void update()
        {
            gel.moveDown();
            gel.update();
        }
    }
}
