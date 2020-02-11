using System;

namespace LoZCloe
{
    public class UpMovingDodongoState : IEnemyState
    {
        private Dodongo dodongo;
        private DodongoSprite sprite;

        public UpMovingDodongoState(Dodongo dodongo)
        {
            this.dodongo = dodongo;
            sprite = EnemySpriteFactory.Instance.createUpMovingDodongoSprite();
        }
        public void moveLeft()
        {
            dodongo.state = new LeftMovingDodongoState(dodongo);
        }
        public void moveRight()
        {
            dodongo.state = new RightMovingDodongoState(dodongo);
        }
        public void moveUp()
        {
           // Blank b/c already moving up
        }
        public void moveDown()
        {
            dodongo.state = new DownMovingDodongoState(dodongo);
        }

        public void takeDamage()
        {
            this.dodongo.health--;
            if (this.dodongo.health-- == 0)
            {
                dodongo.state.die();
            }
        }
        public void die()
        {

        }

        public void update()
        {
            dodongo.location = new Vector(dodongo.location.X, dodongo.location.Y - 3);
            sprite.update();
        }
    }
}
