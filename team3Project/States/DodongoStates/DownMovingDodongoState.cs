using System;

namespace LoZCloe
{
    public class DownMovingDodongoState : IEnemyState
    {
        private DodongoSprite dodongo;
        public DownMovingDodongoState(DodongoSprite dodongoSprite)
        {
            this.dodongo = dodongoSprite;
            EnemySpriteFactory.Instance.createDownMovingDodongoSprite();
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
            dodongo.state = new UpMovingDodongoState(dodongo);
        }
        public void moveDown()
        {
            // Blank b/c already moving up
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
            dodongo.moveDown();
            dodongo.update();
        }
    }
}
