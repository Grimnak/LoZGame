using System;

namespace LoZCloe
{
    public class UpLeftMovingKeeseState : IEnemyState
    {
        private KeeseSprite keese;
        public UpLeftMovingKeeseState(KeeseSprite keeseSprite)
        {
            this.keese = keeseSprite;
            EnemySpriteFactory.Instance.createUpLeftMovingKeeseSprite();
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
            //Blank b/c already moving downRight
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
            keese.moveUp();
            keese.update();
        }
    }
}
