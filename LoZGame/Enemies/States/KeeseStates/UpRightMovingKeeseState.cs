using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class UpRightMovingKeeseState : IEnemyState
    {
        private Keese keese;
        private IKeeseSprite sprite;

        public UpRightMovingKeeseState(Keese keese)
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
            // Blank b/c already moving up
        }
        public void moveDown()
        {
            keese.currentState = new DownMovingKeeseState(keese);
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
            keese.currentLocation = new Vector2(keese.currentLocation.X + 3, keese.currentLocation.Y - 3);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, keese.currentLocation, Color.White);
        }
    }
}
