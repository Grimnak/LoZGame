using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DeadDodongoState : IEnemyState
    {
        private Dodongo dodongo;
        private DeadEnemySprite sprite;

        public DeadDodongoState(Dodongo dodongo)
        {
            sprite = EnemySpriteFactory.Instance.createDeadEnemySprite();
            this.dodongo = dodongo;
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
            sprite.Draw(sb, dodongo.currentLocation, Color.White);
        }

    }
}
