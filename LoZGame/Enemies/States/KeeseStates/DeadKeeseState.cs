using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class DeadKeeseState : IEnemyState
    {
        private Keese keese;
        private IKeeseSprite sprite;

        public DeadKeeseState(Keese keese)
        {
            this.keese = keese;
            sprite = EnemySpriteFactory.Instance.createDeadKeeseSprite();
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
            // Blank b/c already moving down
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
            keese.currentState = new DownRightMovingKeeseState(keese);
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

        }

        public void update()
        {
            keese.currentLocation = new Vector2(keese.currentLocation.X, keese.currentLocation.Y + 3);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, keese.currentLocation, Color.White);
        }
    }
}
