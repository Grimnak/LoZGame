using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class DeadRopeState : IEnemyState
    {
        private Rope rope;
        private IRopeSprite sprite;

        public DeadRopeState(Rope rope)
        {
            this.rope = rope;
            sprite = EnemySpriteFactory.Instance.createDeadRopeSprite();
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
            rope.currentState = new UpMovingRopeState(rope);
        }
        public void moveDown()
        {
            // Blank b/c already moving down
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

        }

        public void update()
        {
            rope.currentLocation = new Vector2(rope.currentLocation.X, rope.currentLocation.Y + 3);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, rope.currentLocation, Color.White);
        }
    }
}
