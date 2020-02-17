using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class RightMovingDragonState : IDragonState
    {
        private Dragon dragon;
        private IDragonSprite sprite;

        public RightMovingDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            sprite = EnemySpriteFactory.Instance.createDragonSprite();
        }
        public void moveLeft()
        {
            dragon.CurrentState = new LeftMovingDragonState(dragon);
        }
        public void moveRight()
        {
            // Blank b/c already moving right
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

        public void Update()
        {
            dragon.currentLocation = new Vector2(dragon.currentLocation.X + 1, dragon.currentLocation.Y);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, dragon.currentLocation, Color.White);
        }
    }
}
