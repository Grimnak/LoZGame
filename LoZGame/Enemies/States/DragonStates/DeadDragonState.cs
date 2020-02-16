using System;

namespace LoZClone
{
    public class DeadDragonState : IEnemyState
    {
        private Dragon dragon;
        private IDragonSprite sprite;

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
            sprite.Draw(sb, dragon.currentLocation, Color.White);
        }
    }
}
