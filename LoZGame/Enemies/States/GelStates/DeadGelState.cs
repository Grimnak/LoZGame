using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DeadGelState : IEnemyState
    {
        private readonly Gel gel;
        private readonly DeadEnemySprite sprite;

        public DeadGelState(Gel gel)
        {
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.gel = null;
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
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.gel.currentLocation, Color.White);
        }
    }
}
