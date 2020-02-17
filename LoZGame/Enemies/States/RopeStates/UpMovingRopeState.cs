using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class UpMovingRopeState : IEnemyState
    {
        private readonly Rope rope;
        private readonly IRopeSprite sprite;

        public UpMovingRopeState(Rope rope)
        {
            this.rope = rope;
            this.sprite = EnemySpriteFactory.Instance.CreateRightMovingRopeSprite();
        }

        public void moveLeft()
        {
            this.rope.CurrentState = new LeftMovingRopeState(this.rope);
        }

        public void moveRight()
        {
            this.rope.CurrentState = new RightMovingRopeState(this.rope);
        }

        public void moveUp()
        {
            // Blank b/c already moving up
        }

        public void moveDown()
        {
            this.rope.CurrentState = new DownMovingRopeState(this.rope);
        }

        public void takeDamage()
        {
            this.rope.Health--;
            if (this.rope.Health == 0)
            {
                this.rope.CurrentState.die();
            }
        }

        public void die()
        {
            this.rope.CurrentState = new DeadRopeState(this.rope);
        }

        public void Update()
        {
            this.rope.currentLocation = new Vector2(this.rope.currentLocation.X, this.rope.currentLocation.Y - 2);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.rope.currentLocation, Color.White);
        }
    }
}
