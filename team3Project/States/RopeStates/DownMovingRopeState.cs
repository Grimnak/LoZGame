using System;

namespace LoZCloe
{
    public class DownMovingRopeState : IEnemyState
    {
        private RopeSprite rope;
        public DownMovingRopeState(RopeSprite ropeSprite)
        {
            this.rope = ropeSprite;
            EnemySpriteFactory.Instance.createDownMovingRopeSprite();
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
            rope.moveDown();
            rope.update();
        }
    }
}
