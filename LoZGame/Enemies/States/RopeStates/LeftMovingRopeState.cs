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
            rope.CurrentState = new RightMovingRopeState(rope);
        }
        public void moveUp()
        {
            rope.CurrentState = new UpMovingRopeState(rope);
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
            rope.currentLocation = new Vector2(rope.currentLocation.X - 3, rope.currentLocation.Y);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, rope.currentLocation, Color.White);
        }
    }
}
