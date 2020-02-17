using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DeadDragonState : IDragonState
    {
        private Dragon dragon;
        private DeadEnemySprite sprite;

        public DeadDragonState(Dragon dragon)
        {
            sprite = EnemySpriteFactory.Instance.createDeadEnemySprite();
            this.dragon = null;
        }
        public void moveLeft()
        {
        }
        public void moveRight()
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
        
        public void stop()
        {
        }
        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, dragon.currentLocation, Color.White);
        }
    }
}
