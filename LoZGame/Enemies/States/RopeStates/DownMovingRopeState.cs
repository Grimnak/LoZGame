using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DownMovingRopeState : IEnemyState
    {
        private Rope rope;
        private IRopeSprite sprite;

        public DownMovingRopeState(Rope rope)
        {
            this.rope = rope;
            sprite = EnemySpriteFactory.Instance.createLeftMovingRopeSprite();
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
            if (this.rope.Health == 0)
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
            rope.currentLocation = new Vector2(rope.currentLocation.X, rope.currentLocation.Y + 2);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, rope.currentLocation, Color.White);
        }
    }
}
