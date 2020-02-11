using System;

namespace LoZCloe
{
    public class UpMovingRopeState : IEnemyState
    {
        private Rope rope;
        private RopeSprite sprite;

        public UpMovingRopeState(Rope rope)
        {
            this.rope = rope;
            sprite = EnemySpriteFactory.Instance.createUpMovingRopeSprite();
        }
        public void moveLeft()
        {
            rope.state = new LeftMovingRopeState(rope);
        }
        public void moveRight()
        {
            rope.state = new RightMovingRopeState(rope);
        }
        public void moveUp()
        {
            // Blank b/c already moving up
        }
        public void moveDown()
        {
            rope.state = new DownMovingRopeState(rope);
        }

        public void takeDamage()
        {
            this.rope.health--;
            if (this.rope.health-- == 0)
            {
                rope.state.die();
            }
        }
        public void die()
        {

        }

        public void update()
        {
            rope.location = new Vector(rope.location.X, rope.location.Y - 3);
            sprite.update();
        }
    }
}
