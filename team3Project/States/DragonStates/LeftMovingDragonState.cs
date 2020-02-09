using System;

namespace LoZCloe
{
    public class LeftMovingDragonState : IEnemyState
    {
        private DragonSprite dragon;
        public LeftMovingDragonState(DragonSprite dragonSprite)
        {
            this.dragon = dragonSprite;
            EnemySpriteFactory.Instance.createLeftMovingDragonSprite();
        }
        public void moveLeft()
        {
            // Blank b/c already moving left
        }
        public void moveRight()
        {
            dragon.state = new RightMovingDragonState(dragon);
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
            dragon.moveLeft();
            dragon.update();
        }
    }
}
