using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class LeftMovingGoriyaState : IGoriyaState
    {
        private readonly Goriya goriya;
        private readonly IGoriyaSprite sprite;

        public LeftMovingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            this.sprite = EnemySpriteFactory.Instance.CreateLeftMovingGoriyaSprite();
        }

        public void moveLeft()
        {
            // Blank b/c already moving down
        }

        public void moveRight()
        {
            this.goriya.CurrentState = new RightMovingGoriyaState(this.goriya);
        }

        public void moveUp()
        {
            this.goriya.CurrentState = new UpMovingGoriyaState(this.goriya);
        }

        public void moveDown()
        {
            this.goriya.CurrentState = new DownMovingGoriyaState(this.goriya);
        }

        public void attack()
        {
            this.goriya.CurrentState = new AttackingGoriyaState(this.goriya);

        }

        public void takeDamage()
        {
            this.goriya.Health--;
            if (this.goriya.Health == 0)
            {
                this.goriya.CurrentState.die();
            }
        }

        public void die()
        {
            this.goriya.CurrentState = new DeadGoriyaState(this.goriya);
        }

        public void Update()
        {
            this.goriya.currentLocation = new Vector2(this.goriya.currentLocation.X - 1, this.goriya.currentLocation.Y);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.goriya.currentLocation, Color.White);
        }
    }
}
