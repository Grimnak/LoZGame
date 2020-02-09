using System;

namespace LoZCloe
{
    public class DownLeftMovingKeeseState : IEnemyState
    {
        private KeeseSprite keese;
        public DownLeftMovingKeeseState(KeeseSprite keeseSprite)
        {
            this.keese = keeseSprite;
            EnemySpriteFactory.Instance.createDownLeftMovingKeeseSprite();
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
            //Blank b/c already moving downRight
        }
        public void moveDownRight()
        {
            keese.state = new DownRightMovingKeeseState(keese);
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
            keese.moveLeft();
            keese.moveDown();
            keese.update();
        }
    }
}
