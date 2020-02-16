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
            rope.CurrentState = new LeftMovingRopeState(rope);
        }
        public void moveRight()
        {
            rope.CurrentState = new RightMovingRopeState(rope);
        }
        public void moveUp()
        {
            // Blank b/c already moving up
        }
        public void moveDown()
        {
            rope.CurrentState = new DownMovingRopeState(rope);
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
            rope.CurrentState = new DeadRopeState(rope);
        }

        public void Update()
        {
            rope.currentLocation = new Vector2(rope.currentLocation.X, rope.currentLocation.Y - 3);
            sprite.Update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, rope.currentLocation, Color.White);
        }
    }
}
