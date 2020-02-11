using System;

namespace LoZCloe
{
    public class UpMovingGoriyaState : IEnemyState
    {
        private Goriya goriya;
        private GoriyaSprite sprite;
        public UpMovingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            sprite = EnemySpriteFactory.Instance.createUpMovingGoriyaSprite();
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
            // Blank b/c already moving down
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
            goriya.location = new Vector(goriya.location.X, goriya.location.Y - 3);
            sprite.update();
        }
    }
}
