using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class UpMovingRopeState : IEnemyState
    {
        private Rope rope;
        private IRopeSprite sprite;

        public UpMovingRopeState(Rope rope)
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
            rope.currentState = new RightMovingRopeState(rope);
        }
        public void moveUp()
        {
            // Blank b/c already moving up
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
            rope.currentLocation = new Vector2(rope.currentLocation.X, rope.currentLocation.Y - 3);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, rope.currentLocation, Color.White);
        }
    }
}
