using System;

namespace LoZCloe
{
    public class RightMovingRopeState : IEnemyState
    {
        private RopeSprite rope;
        public RightMovingRopeState(RopeSprite ropeSprite)
        {
            this.rope = ropeSprite;
            EnemySpriteFactory.Instance.createRightMovingRopeSprite();
        }
        public void moveLeft()
        {
            rope.state = new LeftMovingRopeState(rope);
        }
        public void moveRight()
        {
            // Blank b/c already moving right
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
            rope.moveRight();
            rope.update();
        }
    }
}
