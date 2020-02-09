using System;

namespace LoZCloe
{
    public class LeftMovingDodongoState : IEnemyState
    {
        private DodongoSprite dodongo;
        public LeftMovingDodongoState(DodongoSprite dodongoSprite)
        {
            this.dodongo = dodongoSprite;
            EnemySpriteFactory.Instance.createLeftMovingDodongoSprite();
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
            dodongo.moveLeft();
            dodongo.update();
        }
    }
}
