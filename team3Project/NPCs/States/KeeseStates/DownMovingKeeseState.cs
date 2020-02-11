using System;

namespace LoZCloe
{
    public class DownMovingKeeseState : IEnemyState
    {
        private Keese keese;
        private KeeseSprite sprite;

        public DownMovingKeeseState(Keese keese)
        {
            this.keese = keese;
            sprite = EnemySpriteFactory.Instance.createDownMovingKeeseSprite();
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
            // Blank b/c already moving down
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
            keese.location = new Vector(keese.location.X, keese.location.Y + 3);
            sprite.update();
        }
    }
}
