using System;

namespace LoZCloe
{
    public class RightMovingGelState : IEnemyState
    {
        private GelSprite gel;
        public RightMovingGelState(GelSprite gelSprite)
        {
            this.gel = gelSprite;
            EnemySpriteFactory.Instance.createRightMovingGelSprite();
        }
        public void moveLeft()
        {
            gel.state = new LeftMovingGelState(gel);
        }
        public void moveRight()
        {
            // Blank b/c already moving right
        }
        public void moveUp()
        {
            gel.state = new UpMovingGelState(gel);
        }
        public void moveDown()
        {
            gel.state = new DownMovingGelState(gel);
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
            gel.moveRight();
            gel.update();
        }
    }
}
