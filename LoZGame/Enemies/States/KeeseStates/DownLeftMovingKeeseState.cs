using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class DownLeftMovingKeeseState : IEnemyState
    {
        private Keese keese;
        private IKeeseSprite sprite;

        public DownLeftMovingKeeseState(Keese keese)
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
            keese.CurrentState = new UpMovingKeeseState(keese);
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
            //Blank b/c already moving downRight
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
            keese.currentLocation = new Vector2(keese.currentLocation.X - 3, keese.currentLocation.Y + 3);
            sprite.Update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, keese.currentLocation, Color.White);
        }
    }
}
