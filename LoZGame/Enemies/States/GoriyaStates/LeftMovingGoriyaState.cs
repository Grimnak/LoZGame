using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class LeftMovingGoriyaState : IEnemyState
    {
        private Goriya goriya;
        private IGoriyaSprite sprite;

        public LeftMovingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            sprite = EnemySpriteFactory.Instance.createLeftMovingGoriyaSprite();
        }
        public void moveLeft()
        {
            // Blank b/c already moving down
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
            goriya.currentLocation = new Vector2(goriya.currentLocation.X - 3, goriya.currentLocation.Y);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, goriya.currentLocation, Color.White);
        }
    }
}
