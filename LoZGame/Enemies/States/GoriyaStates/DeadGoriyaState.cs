using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DeadGoriyaState : IGoriyaState
    {
        private readonly Goriya goriya;
        private readonly DeadEnemySprite sprite;

        public DeadGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
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
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.goriya.currentLocation, Color.White);
        }
    }
}
