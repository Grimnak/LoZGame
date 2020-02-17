using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class UpLeftMovingKeeseState : IKeeseState
    {
        private Keese keese;
        private IKeeseSprite sprite;

        public UpLeftMovingKeeseState(Keese keese)
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
            //Blank b/c already moving downRight
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
        
        public void attack() 
        {
        }

        public void Update()
        {
            keese.currentLocation = new Vector2(keese.currentLocation.X - 3, keese.currentLocation.Y - 3);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, keese.currentLocation, Color.White);
        }
    }
}
