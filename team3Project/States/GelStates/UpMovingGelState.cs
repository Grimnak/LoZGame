using System;

namespace LoZCloe
{
    public class UpMovingGelState : IEnemyState
    {
        private GelSprite gel;
        public UpMovingGelState(GelSprite gelSprite)
        {
            this.gel = gelSprite;
            EnemySpriteFactory.Instance.createUpMovingGelSprite();
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
            // Blank b/c already moving up
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
            gel.moveUp();
            gel.update();
        }
    }
}
