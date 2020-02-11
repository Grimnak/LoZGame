using System;

namespace LoZCloe
{
    public class UpRightMovingKeeseState : IEnemyState
    {
        private Keese keese;
        private KeeseSprite sprite;

        public UpRightMovingKeeseState(Keese keese)
        {
            this.keese = keese;
            sprite = EnemySpriteFactory.Instance.createUpRightMovingKeeseSprite();
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
            keese.location = new Vector(keese.location.X + 3, keese.location.Y - 3);
            sprite.update();
        }
    }
}
