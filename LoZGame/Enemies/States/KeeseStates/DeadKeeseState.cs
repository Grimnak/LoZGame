using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DeadKeeseState : IKeeseState
    {
        private Keese keese;
        private DeadEnemySprite sprite;

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

        public void takeDamage()
        {
        }
        public void die()
        {
        }

        public void attack()
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
