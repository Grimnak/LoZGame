using System;

namespace LoZCloe
{
    public class LeftMovingGelState : IEnemyState
    {
        private GelSprite gel;
        public LeftMovingGelState(GelSprite gelSprite)
        {
            this.gel = gelSprite;
            EnemySpriteFactory.Instance.createLeftMovingGelSprite();
        }
        public void moveLeft()
        {
            // Blank b/c already moving left
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
            gel.moveLeft();
            gel.update();
        }
    }
}
