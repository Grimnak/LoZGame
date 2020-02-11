using System;

namespace LoZCloe
{
    public class RightMovingGelState : IEnemyState
    {
        private Gel gel;
        private GelSprite sprite;

        public RightMovingGelState(Gel gel)
        {
            this.gel = gel;
            sprite = EnemySpriteFactory.Instance.createRightMovingGelSprite();
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
            gel.location = new Vector(gel.location.X + 3, gel.location.Y);
            sprite.update();
        }
    }
}
