using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class RightMovingRopeState : IEnemyState
    {
        private Rope rope;
        private IRopeSprite sprite;

        public RightMovingRopeState(Rope rope)
        {
            this.rope = rope;
            sprite = EnemySpriteFactory.Instance.createRightMovingRopeSprite();
        }
        public void moveLeft()
        {
            rope.currentState = new LeftMovingRopeState(rope);
        }
        public void moveRight()
        {
            // Blank b/c already moving right
        }
        public void moveUp()
        {
            rope.currentState = new UpMovingRopeState(rope);
        }
        public void moveDown()
        {
            rope.currentState = new DownMovingRopeState(rope);
        }

        public void takeDamage()
        {
            this.rope.Health--;
            if (this.rope.Health-- == 0)
            {
                rope.currentState.die();
            }
        }
        public void die()
        {
            rope.currentState = new DeadRopeState(rope);
        }

        public void update()
        {
            rope.currentLocation = new Vector2(rope.currentLocation.X + 3, rope.currentLocation.Y);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, rope.currentLocation, Color.White);
        }
    }
}
