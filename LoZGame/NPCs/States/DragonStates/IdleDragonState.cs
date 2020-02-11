using System;

namespace LoZCloe
{
    public class IdleDragonState : IEnemyState
    {
        private Dragon dragon;
        private DragonSprite sprite;
        public IdleDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            sprite = EnemySpriteFactory.Instance.createIdleDragonSprite();
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
            sprite.update();
        }
    }
}
