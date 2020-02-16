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
            keese.CurrentState = new DownLeftMovingKeeseState(keese);
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
                keese.CurrentState.die();
            }
        }
        public void die()
        {
            keese.CurrentState = new DeadKeeseState(keese);
        }

        public void Update()
        {
            keese.currentLocation = new Vector2(keese.currentLocation.X + 3, keese.currentLocation.Y + 3);
            sprite.Update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, keese.currentLocation, Color.White);
        }
    }
}
