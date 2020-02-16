using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class AttackingGoriyaState : IEnemyState
    {
        private Goriya goriya;
        private IGoriyaSprite sprite;

        public AttackingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            sprite = EnemySpriteFactory.Instance.createAttackingGoriyaSprite();
        }
        public void moveLeft()
        {
            goriya.currentState = new LeftMovingGoriyaState(goriya);
        }
        public void moveRight()
        {
            goriya.currentState = new RightMovingGoriyaState(goriya);
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
            //Blank b/c already attacking
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
            goriya.currentState = new DeadGoriyaState(goriya);
        }

        public void update()
        {
            goriya.currentLocation = new Vector2(goriya.currentLocation.X, goriya.currentLocation.Y + 3);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, goriya.currentLocation, Color.White);
        }
    }
}
