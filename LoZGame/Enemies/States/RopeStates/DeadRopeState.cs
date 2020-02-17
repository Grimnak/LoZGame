using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DeadRopeState : IEnemyState
    {
        private readonly Rope rope;
        private readonly DeadEnemySprite sprite;

        public DeadRopeState(Rope rope)
        {
            this.rope = rope;
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

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.rope.currentLocation, Color.White);
        }
    }
}
