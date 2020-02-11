using System;

namespace LoZCloe
{
    public class DownMovingGelState : IEnemyState
    {
        private Gel gel;
        private GelSprite sprite;
        public DownMovingGelState(Gel gel)
        {
            this.gel = gel;
            sprite = EnemySpriteFactory.Instance.createDownMovingGelSprite();
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
            gel.location = new Vector(gel.location.X, gel.location.Y + 3);
            sprite.update();
        }
    }
}
