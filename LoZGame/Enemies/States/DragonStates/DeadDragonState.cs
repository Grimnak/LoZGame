using System;

namespace LoZClone
{
    public class DeadDragonState : IEnemyState
    {
        private Dragon dragon;
        private IDragonSprite sprite;

        public DeadDragonState(Dragon dragon)
        {
            sprite = EnemySpriteFactory.Instance.createDeadSprite();
            this.dragon = null;
        }
        public void moveLeft()
        {
            dragon.currentState = new LeftMovingDragonState(dragon);
        }
        public void moveRight()
        {
            dragon.currentState = new RightMovingDragonState(dragon);
        }
        public void moveUp()
        {
            dragon.currentState = new UpMovingDragonState(dragon);
        }
        public void moveDown()
        {
            dragon.currentState = new DownMovingDragonState(dragon);
        }
        public void stop()
        {
            // Blank b/c already moving left
        }
        public void attack()
        {
            dragon.currentState = new AttackingDragonState(dragon);
        }

        public void takeDamage()
        {
            this.dragon.Health--;
            if (this.dragon.Health-- == 0)
            {
                dragon.currentState.die();
            }
        }
        public void die()
        {

        }

        public void update()
        {         
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, dragon.currentLocation, Color.White);
        }
    }
}
