using System;

namespace LoZCloe
{
    public class RightMovingDragonState : IEnemyState
    {
        private DragonSprite dragon;
        private DragonSprite sprite;
        public RightMovingDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            sprite = EnemySpriteFactory.Instance.createRightMovingDragonSprite();
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
        public void stop()
        {
            dragon.state = new IdleDragonState(dragon);
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
            dragon.location = new Vector(dragon.location.X + 3, dragon.location.Y);
            sprite.update();
        }
    }
}
