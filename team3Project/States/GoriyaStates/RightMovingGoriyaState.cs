using System;

namespace LoZCloe
{
    public class RightMovingGoriyaState : IEnemyState
    {
        private GoriyaSprite goriya;
        public RightMovingGoriyaState(GoriyaSprite goriyaSprite)
        {
            this.goriya = goriyaSprite;
            EnemySpriteFactory.Instance.createRightMovingGoriyaSprite();
        }
        public void moveLeft()
        {
            goriya.state = new LeftMovingGoriyaState(goriya);
        }
        public void moveRight()
        {
            // Blank b/c already moving down
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
            goriya.moveRight();
            goriya.update();
        }
    }
}
