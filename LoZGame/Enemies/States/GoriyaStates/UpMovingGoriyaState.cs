using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class UpMovingGoriyaState : IEnemyState
    {
        private Goriya goriya;
        private IGoriyaSprite sprite;

        public UpMovingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            sprite = EnemySpriteFactory.Instance.createUpMovingGoriyaSprite();
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
            // Blank b/c already moving down
        }
        public void moveDown()
        {
            goriya.CurrentState = new DownMovingGoriyaState(goriya);
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
            goriya.currentLocation = new Vector2(goriya.currentLocation.X, goriya.currentLocation.Y - 3);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, goriya.currentLocation, Color.White);
        }
    }
}
