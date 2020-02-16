using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class DownMovingGoriyaState : IEnemyState
    {
        private Goriya goriya;
        private IGoriyaSprite sprite;

        public DownMovingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            sprite = EnemySpriteFactory.Instance.createDownMovingGoriyaSprite();
        }
        public void moveLeft()
        {
            goriya.CurrentState = new LeftMovingGoriyaState(goriya);
        }
        public void moveRight()
        {
            goriya.CurrentState = new RightMovingGoriyaState(goriya);
        }
        public void moveUp()
        {
            goriya.CurrentState = new UpMovingGoriyaState(goriya);
        }
        public void moveDown()
        {
            // Blank b/c already moving down
        }
        public void attack()
        {
            goriya.CurrentState = new AttackingGoriyaState(goriya);
        }

        public void takeDamage()
        {
            this.goriya.Health--;
            if (this.goriya.Health-- == 0)
            {
                goriya.CurrentState.die();
            }
        }
        public void die()
        {
            goriya.CurrentState = new DeadGoriyaState(goriya);
        }

        public void Update()
        {
            goriya.currentLocation = new Vector2(goriya.currentLocation.X, goriya.currentLocation.Y + 3);
            sprite.Update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, goriya.currentLocation, Color.White);
        }
    }
}
