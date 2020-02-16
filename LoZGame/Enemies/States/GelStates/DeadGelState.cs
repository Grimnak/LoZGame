using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class DeadGelState : IEnemyState
    {
        private Gel gel;
        private IGelSprite sprite;

        public DeadGelState(Gel gel)
        {
            sprite = EnemySpriteFactory.Instance.createDeadEnemySprite();
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
            sprite.Update();
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, gel.currentLocation, Color.White);
        }
    }
}
