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
            rope.CurrentState = new LeftMovingRopeState(rope);
        }
        public void moveRight()
        {
            rope.CurrentState = new RightMovingRopeState(rope);
        }
        public void moveUp()
        {
            rope.CurrentState = new UpMovingRopeState(rope);
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
                rope.CurrentState.die();
            }
        }
        public void die()
        {

        }

        public void update()
        {
            rope.currentLocation = new Vector2(rope.currentLocation.X, rope.currentLocation.Y + 3);
            sprite.Update();
        }
    }
}
