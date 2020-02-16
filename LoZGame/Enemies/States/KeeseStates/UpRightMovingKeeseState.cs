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
            keese.currentLocation = new Vector2(keese.currentLocation.X + 3, keese.currentLocation.Y - 3);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, keese.currentLocation, Color.White);
        }
    }
}
