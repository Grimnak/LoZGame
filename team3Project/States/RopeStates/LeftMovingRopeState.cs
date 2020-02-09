using System;

namespace LoZCloe
{
    public class LeftMovingRopeState : IEnemyState
    {
        private RopeSprite rope;
        public LeftMovingRopeState(RopeSprite ropeSprite)
        {
            this.rope = ropeSprite;
            EnemySpriteFactory.Instance.createLeftMovingRopeSprite();
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
            rope.moveLeft();
            rope.update();
        }
    }
}
