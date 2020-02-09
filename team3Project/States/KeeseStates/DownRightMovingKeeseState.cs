using System;

namespace LoZCloe
{
    public class DownRightMovingKeeseState : IEnemyState
    {
        private KeeseSprite keese;
        public DownRightMovingKeeseState(KeeseSprite keeseSprite)
        {
            this.keese = keeseSprite;
            EnemySpriteFactory.Instance.createDownRightMovingKeeseSprite();
        }

        public void moveLeft()
        {
            keese.state = new LeftMovingKeeseState(keese);
        }
        public void moveRight()
        {
            keese.state = new RightMovingKeeseState(keese);
        }
        public void moveUp()
        {
            keese.state = new UpMovingKeeseState(keese);
        }
        public void moveDown()
        {
            keese.state = new DownMovingKeeseState(keese);
        }
        public void moveUpLeft()
        {
            keese.state = new UpLeftMovingKeeseState(keese);
        }
        public void moveUpRight()
        {
            keese.state = new UpRightMovingKeeseState(keese);
        }
        public void moveDownLeft()
        {
            keese.state = new DownLeftMovingKeeseState(keese);
        }
        public void moveDownRight()
        {
           //Blank b/c already moving downRight
        }

        public void takeDamage()
        {
            this.keese.health--;
            if (this.keese.health-- == 0)
            {
                keese.state.die();
            }
        }
        public void die()
        {

        }

        public void update()
        {
            keese.moveRight();
            keese.moveDown();
            keese.update();
        }
    }
}
