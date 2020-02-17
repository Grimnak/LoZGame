using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DeadDodongoState : IEnemyState
    {
        private readonly Dodongo dodongo;
        private readonly DeadEnemySprite sprite;

        public DeadDodongoState(Dodongo dodongo)
        {
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
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
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.dodongo.currentLocation, Color.White);
        }

    }
}
