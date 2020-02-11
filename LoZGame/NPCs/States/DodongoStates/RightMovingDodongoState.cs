using System;

namespace LoZCloe
{
    public class RightMovingDodongoState : IEnemyState
    {
        private Dodongo dodongo;
        private DodongoSprite sprite;

        public RightMovingDodongoState(Dodongo dodongo)
        {
            this.dodongo = dodongo;
            sprite = EnemySpriteFactory.Instance.createRightMovingDodongoSprite();
        }
        public void moveLeft()
        {
            dodongo.state = new LeftMovingDodongoState(dodongo);
        }
        public void moveRight()
        {
            // Blank b/c already moving right
        }
        public void moveUp()
        {
            dodongo.state = new UpMovingDodongoState(dodongo);
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
            dodongo.location = new Vector(dodongo.location.X + 3, dodongo.location.Y);
            sprite.update();
        }
    }
}
