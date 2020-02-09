using System;

namespace LoZCloe
{
    public class DownMovingGoriyaState : IEnemyState
    {
        private GoriyaSprite goriya;
        public DownMovingGoriyaState(GoriyaSprite goriyaSprite)
        {
            this.goriya = goriyaSprite;
            EnemySpriteFactory.Instance.createDownMovingGoriyaSprite();
        }
        public void moveLeft()
        {
            goriya.state = new LeftMovingGoriyaState(goriya);
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
            // Blank b/c already moving down
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
            goriya.moveDown();
        }
    }
}
