using System;

namespace LoZCloe
{
    public class LeftMovingDodongoState : IEnemyState
    {
        private Dodongo dodongo;
        private DodongoSprite sprite;

        public LeftMovingDodongoState(Dodongo dodongoe)
        {
            this.dodongo = dodongo;
            sprite = EnemySpriteFactory.Instance.createLeftMovingDodongoSprite();
        }
        public void moveLeft()
        {
            // Blank b/c already moving left
        }
        public void moveRight()
        {
            dodongo.state = new RightMovingDodongoState(dodongo);
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
            dodongo.location = new Vector(dodongo.location.X - 3, dodongo.location.Y);
            sprite.update();
        }
    }
}
