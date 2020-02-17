using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DeadKeeseState : IKeeseState
    {
        private readonly Keese keese;
        private readonly DeadEnemySprite sprite;

        public DeadKeeseState(Keese keese)
        {
            this.keese = keese;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
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

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.keese.currentLocation, Color.White);
        }
    }
}
