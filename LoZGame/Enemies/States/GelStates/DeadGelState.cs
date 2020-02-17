using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DeadGelState : IEnemyState
    {
        private Gel gel;
        private DeadEnemySprite sprite;

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

        public void attack()
        {
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
