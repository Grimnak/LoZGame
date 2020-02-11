using System;

namespace LoZCloe
{
    public class DownMovingRopeState : IEnemyState
    {
        private Rope rope;
        private RopeSprite sprite;

        public DownMovingRopeState(Rope rope)
        {
            this.rope = rope;
            sprite = EnemySpriteFactory.Instance.createDownMovingRopeSprite();
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
            rope.state = new UpMovingRopeState(rope);
        }
        public void moveDown()
        {
            // Blank b/c already moving down
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
            rope.location = new Vector(rope.location.X, rope.location.Y + 3);
            sprite.update();
        }
    }
}
