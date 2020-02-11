using System;

namespace LoZCloe
{
    public class LeftMovingDragonState : IEnemyState
    {
        private DragonSprite dragon;
        private DragonSprite sprite;
        public LeftMovingDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            sprite = EnemySpriteFactory.Instance.createLeftMovingDragonSprite();
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
            dragon.location = new Vector(dragon.location.X - 3, dragon.location.Y);
            sprite.update();
        }
    }
}
