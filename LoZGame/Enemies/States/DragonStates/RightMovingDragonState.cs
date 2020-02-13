using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class RightMovingDragonState : IEnemyState
    {
        private Dragon dragon;
        private IDragonSprite sprite;

        public RightMovingDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            sprite = EnemySpriteFactory.Instance.createRightMovingDragonSprite();
        }
        public void moveLeft()
        {
            dragon.CurrentState = new LeftMovingDragonState(dragon);
        }
        public void moveRight()
        {
            // Blank b/c already moving right
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
            dragon.CurrentState = new DeadDragonState(dragon);
        }

        public void update()
        {
            dragon.currentLocation = new Vector2(dragon.currentLocation.X + 3, dragon.currentLocation.Y);
            sprite.Update();
        }
    }
}
