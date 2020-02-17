using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class RightMovingRopeState : IEnemyState
    {
        private readonly Rope rope;
        private readonly IRopeSprite sprite;

        public RightMovingRopeState(Rope rope)
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
            // Blank b/c already moving right
        }

        public void moveUp()
        {
            this.rope.CurrentState = new UpMovingRopeState(this.rope);
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
            this.rope.currentLocation = new Vector2(this.rope.currentLocation.X + 2, this.rope.currentLocation.Y);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.rope.currentLocation, Color.White);
        }
    }
}
