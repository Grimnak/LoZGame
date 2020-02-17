using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DeadDragonState : IDragonState
    {
        private readonly Dragon dragon;
        private readonly DeadEnemySprite sprite;

        public DeadDragonState(Dragon dragon)
        {
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
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
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.dragon.currentLocation, Color.White);
        }
    }
}
