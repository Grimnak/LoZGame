using System;

namespace LoZCloe
{
    public class UpMovingDodongoState : IEnemyState
    {
        private DodongoSprite dodongo;
        public UpMovingDodongoState(DodongoSprite dodongoSprite)
        {
            this.dodongo = dodongoSprite;
            EnemySpriteFactory.Instance.createUpMovingDodongoSprite();
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
            dodongo.moveUp();
            dodongo.update();
        }
    }
}
