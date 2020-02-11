using System;

namespace LoZCloe
{
    public class LeftMovingGoriyaState : IEnemyState
    {
        private Goriya goriya;
        private GoriyaSprite sprite;

        public LeftMovingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            sprite = EnemySpriteFactory.Instance.createLeftMovingGoriyaSprite();
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
            goriya.location = new Vector(goriya.location.X - 3, goriya.location.Y);
            sprite.update();
        }
    }
}
