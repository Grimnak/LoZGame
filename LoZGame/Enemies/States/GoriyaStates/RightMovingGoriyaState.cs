using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class RightMovingGoriyaState : IEnemyState
    {
        private Goriya goriya;
        private IGoriyaSprite sprite;

        public RightMovingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            sprite = EnemySpriteFactory.Instance.createRightMovingGoriyaSprite();
        }
        public void moveLeft()
        {
            goriya.currentState = new LeftMovingGoriyaState(goriya);
        }
        public void moveRight()
        {
            // Blank b/c already moving down
        }
        public void moveUp()
        {
            goriya.currentState = new UpMovingGoriyaState(goriya);
        }
        public void moveDown()
        { 
            goriya.currentState = new DownMovingGoriyaState(goriya);
        }
        public void attack()
        {
            goriya.currentState = new AttackingGoriyaState(goriya);

        }

        public void takeDamage()
        {
            this.goriya.Health--;
            if (this.goriya.Health-- == 0)
            {
                goriya.currentState.die();
            }
        }
        public void die()
        {

        }

        public void update()
        {
            goriya.currentLocation = new Vector2(goriya.currentLocation.X + 3, goriya.currentLocation.Y);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, goriya.currentLocation, Color.White);
        }
    }
}
