using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class LeftMovingDragonState : IEnemyState
    {
        private Dragon dragon;
        private IDragonSprite sprite;

        public LeftMovingDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            sprite = EnemySpriteFactory.Instance.createDragonSprite();
        }
        public void moveLeft()
        {
            // Blank b/c already moving left
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
            dragon.currentState = new IdleDragonState(dragon);
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
            dragon.currentState = new DeadDragonState(dragon);
        }

        public void update()
        {
            dragon.currentLocation = new Vector2(dragon.currentLocation.X - 3, dragon.currentLocation.Y);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, dragon.currentLocation, Color.White);
        }
    }
}
