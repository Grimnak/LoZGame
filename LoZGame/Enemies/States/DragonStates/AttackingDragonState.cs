using System;

namespace LoZClone
{
    public class AttackingDragonState : IEnemyState
    {
        private Dragon dragon;
        private IDragonSprite sprite;
        private FireballSprite fireball;

        public AttackingDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            sprite = EnemySpriteFactory.Instance.createIdleDragonSprite();

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
            dragon.CurrentState = new IdleDragonState(dragon);
        }
        public void attack()
        {
            // Blank b/c already attacking
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
            dragon.CurrentState = new DeadDragonState(dragon);
        }

        public void update()
        {         
            sprite.Update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, dragon.currentLocation, Color.White);
        }
    }
}
