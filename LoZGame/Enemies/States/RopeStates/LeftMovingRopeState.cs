using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class LeftMovingRopeState : IEnemyState
    {
        private Rope rope;
        private IRopeSprite sprite;

        public LeftMovingRopeState(Rope rope)
        {
            this.rope = rope;
            sprite = EnemySpriteFactory.Instance.createLeftMovingRopeSprite();
        }
        public void moveLeft()
        {
            // Blank b/c already moving left
        }
        public void moveRight()
        {
            rope.currentState = new RightMovingRopeState(rope);
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
            rope.currentLocation = new Vector2(rope.currentLocation.X - 3, rope.currentLocation.Y);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, rope.currentLocation, Color.White);
        }
    }
}
