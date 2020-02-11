using System;

namespace LoZCloe
{
    public class UpMovingGelState : IEnemyState
    {
        private Gel gel;
        private GelSprite sprite;

        public UpMovingGelState(Gel gel)
        {
            this.gel = gel;
            sprite = EnemySpriteFactory.Instance.createUpMovingGelSprite();
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
            gel.location = new Vector(gel.location.X, gel.location.Y - 3);
            sprite.update();
        }
    }
}
