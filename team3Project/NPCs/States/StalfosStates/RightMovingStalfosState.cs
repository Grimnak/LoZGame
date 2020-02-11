using System;

namespace LoZCloe
{
    public class RightMovingStalfosState : IEnemyState
    {
        private Stalfos stalfos;
        private StalfosSprite sprite;

        public RightMovingStalfosState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            sprite = EnemySpriteFactory.Instance.createRightMovingStalfosSprite();
        }
        public void moveLeft()
        {
            stalfos.state = new LeftMovingStalfosState(stalfos);
        }
        public void moveRight()
        {
            // Blank b/c already moving right
        }
        public void moveUp()
        {
            stalfos.state = new UpMovingStalfosState(stalfos);
        }
        public void moveDown()
        {
            stalfos.state = new DownMovingStalfosState(stalfos);
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
            stalfos.location = new Vector(stalfos.location.X + 3, stalfos.location.Y);
            sprite.update();
        }
    }
}
