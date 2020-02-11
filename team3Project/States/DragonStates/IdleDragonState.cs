using System;

namespace LoZCloe
{
    public class IdleDragonState : IEnemyState
    {
        private DragonSprite dragon;
        public IdleDragonState(DragonSprite dragonSprite)
        {
            this.dragon = dragonSprite;
            EnemySpriteFactory.Instance.createIdleDragonSprite();
        }
        public void moveLeft()
        {
            dragon.state = new LeftMovingDragonState(dragon);
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
        public void stop()
        {
            // Blank b/c already moving left
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
