using System;

namespace LoZCloe
{
    public class RightMovingDragonState : IEnemyState
    {
        private DragonSprite dragon;
        public RightMovingDragonState(DragonSprite dragonSprite)
        {
            this.dragon = dragonSprite;
            EnemySpriteFactory.Instance.createRightMovingDragonSprite();
        }
        public void moveLeft()
        {
            dragon.state = new LeftMovingDragonState(dragon);
        }
        public void moveRight()
        {
            // Blank b/c already moving right
        }
        public void moveUp()
        {
            dragon.state = new UpMovingDragonState(dragon);
        }
        public void moveDown()
        {
            dragon.state = new DownMovingDragonState(dragon);
        }

        public void takeDamage()
        {
            this.dragon.health--;
            if (this.dragon.health-- == 0)
            {
                dragon.state.die();
            }
        }
        public void die()
        {

        }

        public void update()
        {
            dragon.moveRight();
            dragon.update();
        }
    }
}
