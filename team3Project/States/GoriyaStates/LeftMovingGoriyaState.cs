using System;

namespace LoZCloe
{
    public class LeftMovingGoriyaState : IEnemyState
    {
        private GoriyaSprite goriya;
        public LeftMovingGoriyaState(GoriyaSprite goriyaSprite)
        {
            this.goriya = goriyaSprite;
            EnemySpriteFactory.Instance.createLeftMovingGoriyaSprite();
        }
        public void moveLeft()
        {
            // Blank b/c already moving down
        }
        public void moveRight()
        {
            goriya.state = new RightMovingGoriyaState(goriya);
        }
        public void moveUp()
        {
            goriya.state = new UpMovingGoriyaState(goriya);
        }
        public void moveDown()
        {
            goriya.state = new DownMovingGoriyaState(goriya);
        }

        public void takeDamage()
        {
            this.goriya.health--;
            if (this.Goriya.health-- == 0)
            {
                goriya.state.die();
            }
        }
        public void die()
        {

        }

        public void update()
        {
            goriya.moveLeft();
        }
    }
}
