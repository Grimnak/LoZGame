using System;

namespace LoZCloe
{
    public class LeftMovingRopeState : IEnemyState
    {
        private Rope rope;
        private RopeSprite sprite;

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
            rope.state = new RightMovingRopeState(rope);
        }
        public void moveUp()
        {
            rope.state = new UpMovingRopeState(rope);
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
            rope.location = new Vector(rope.location.X - 3, rope.location.Y);
            sprite.update();
        }
    }
}
