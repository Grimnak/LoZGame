using System;

namespace LoZCloe
{
    public class UpMovingRopeState : IEnemyState
    {
        private RopeSprite rope;
        public UpMovingRopeState(RopeSprite ropeSprite)
        {
            this.rope = ropeSprite;
            EnemySpriteFactory.Instance.createUpMovingRopeSprite();
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
            rope.moveUp();
            rope.update();
        }
    }
}
