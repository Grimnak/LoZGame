using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class UpMovingKeeseState : IEnemyState
    {
        private Keese keese;
        private IKeeseSprite sprite;

        public UpMovingKeeseState(Keese keese)
        {
            this.keese = keese;
            sprite = EnemySpriteFactory.Instance.createKeeseSprite();
        }

        public void moveLeft()
        {
            keese.CurrentState = new LeftMovingKeeseState(keese);
        }
        public void moveRight()
        {
            keese.CurrentState = new RightMovingKeeseState(keese);
        }
        public void moveUp()
        {
            // Blank b/c already moving up
        }
        public void moveDown()
        {
            keese.CurrentState = new DownMovingKeeseState(keese);
        }
        public void moveUpLeft()
        {
            keese.CurrentState = new UpLeftMovingKeeseState(keese);
        }
        public void moveUpRight()
        {
            keese.CurrentState = new UpRightMovingKeeseState(keese);
        }
        public void moveDownLeft()
        {
            keese.CurrentState = new DownLeftMovingKeeseState(keese);
        }
        public void moveDownRight()
        {
            keese.CurrentState = new DownRightMovingKeeseState(keese);
        }

        public void takeDamage()
        {
            this.keese.Health--;
            if (this.keese.Health-- == 0)
            {
                keese.CurrentState.die();
            }
        }
        public void die()
        {
            keese.CurrentState = new DeadKeeseState(keese);
        }

        public void update()
        {
            keese.currentLocation = new Vector2(keese.currentLocation.X, keese.currentLocation.Y - 3);
            sprite.Update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, keese.currentLocation, Color.White);
        }
    }
}
