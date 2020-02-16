using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class DownRightMovingKeeseState : IEnemyState
    {
        private Keese keese;
        private IKeeseSprite sprite;

        public DownRightMovingKeeseState(Keese keese)
        {
            this.keese = keese;
            sprite = EnemySpriteFactory.Instance.createKeeseSprite();
        }

        public void moveLeft()
        {
            keese.currentState = new LeftMovingKeeseState(keese);
        }
        public void moveRight()
        {
            keese.currentState = new RightMovingKeeseState(keese);
        }
        public void moveUp()
        {
            keese.currentState = new UpMovingKeeseState(keese);
        }
        public void moveDown()
        {
            keese.currentState = new DownMovingKeeseState(keese);
        }
        public void moveUpLeft()
        {
            keese.currentState = new UpLeftMovingKeeseState(keese);
        }
        public void moveUpRight()
        {
            keese.currentState = new UpRightMovingKeeseState(keese);
        }
        public void moveDownLeft()
        {
            keese.currentState = new DownLeftMovingKeeseState(keese);
        }
        public void moveDownRight()
        {
           //Blank b/c already moving downRight
        }

        public void takeDamage()
        {
            this.keese.Health--;
            if (this.keese.Health-- == 0)
            {
                keese.currentState.die();
            }
        }
        public void die()
        {
            keese.currentState = new DeadKeeseState(keese);
        }

        public void update()
        {
            keese.currentLocation = new Vector2(keese.currentLocation.X + 3, keese.currentLocation.Y + 3);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, keese.currentLocation, Color.White);
        }
    }
}
