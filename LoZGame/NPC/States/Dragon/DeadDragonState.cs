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
            dragon.CurrentState = new LeftMovingDragonState(dragon);
        }
        public void moveRight()
        {
            dragon.CurrentState = new RightMovingDragonState(dragon);
        }
        public void moveUp()
        {
            dragon.CurrentState = new UpMovingDragonState(dragon);
        }
        public void moveDown()
        {
            dragon.CurrentState = new DownMovingDragonState(dragon);
        }
        public void stop()
        {
            // Blank b/c already moving left
        }
        public void attack()
        {
            dragon.CurrentState = new AttackingDragonState(dragon);
        }

        public void takeDamage()
        {
            this.dragon.Health--;
            if (this.dragon.Health-- == 0)
            {
                dragon.CurrentState.die();
            }
        }
        public void die()
        {

        }

        public void Update()
        {         
            sprite.Update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, dragon.currentLocation, Color.White);
        }
    }
}
