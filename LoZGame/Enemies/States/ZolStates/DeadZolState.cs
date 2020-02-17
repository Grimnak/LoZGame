using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DeadZolState : IEnemyState
    {
        private Zol zol;
        private DeadEnemySprite sprite;

        public DeadZolState(Zol zol)
        {
            this.zol = zol;
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

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, zol.currentLocation, Color.White);
        }
    }
}
