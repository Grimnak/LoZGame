using System;

namespace LoZCloe
{
    public class UpMovingStalfosState : IEnemyState
    {
        private Stalfos stalfos;
        private StalfosSprite sprite;

        public UpMovingStalfosState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            sprite = EnemySpriteFactory.Instance.createUpMovingStalfosSprite();
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
            // Blank b/c already moving up
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
            stalfos.location = new Vector(stalfos.location.X, stalfos.location.Y - 3);
            sprite.update();
        }
    }
}
