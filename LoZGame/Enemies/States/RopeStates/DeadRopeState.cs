using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DeadRopeState : IEnemyState
    {
        private Rope rope;
        private DeadEnemySprite sprite;

        public DeadRopeState(Rope rope)
        {
            this.rope = rope;
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

        public void attack()
        {
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, rope.currentLocation, Color.White);
        }
    }
}
