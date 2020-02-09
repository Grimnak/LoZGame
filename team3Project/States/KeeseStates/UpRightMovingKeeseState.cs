using System;

namespace LoZCloe
{
    public class UpRightMovingKeeseState : IEnemyState
    {
        private KeeseSprite keese;
        public UpRightMovingKeeseState(KeeseSprite keeseSprite)
        {
            this.keese = keeseSprite;
            EnemySpriteFactory.Instance.createUpRightMovingKeeseSprite();
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
            // Blank b/c already moving up
        }
        public void moveDown()
        {
            keese.state = new DownMovingKeeseState(keese);
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
            keese.moveUp();
            keese.update();
        }
    }
}
