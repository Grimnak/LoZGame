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
            sprite = EnemySpriteFactory.Instance.createDeadEnemySprite();
        }
        public void moveLeft()
        {
        }
        public void moveRight()
        {
        }
        public void moveUp()
        {
        }
        public void moveDown()
        {
        }

        public void takeDamage()
        {
        }
        public void die()
        {
        }

        public void Update()
        {
            sprite.Update();
        }

        public void moveUpLeft()
        {
        }
        public void moveUpRight()
        {
        }
        public void moveDownLeft()
        {
        }
        public void moveDownRight()
        {
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, keese.currentLocation, Color.White);
        }
    }
}
