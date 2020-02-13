using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class UpMovingGelState : IEnemyState
    {
        private Gel gel;
        private IGelSprite sprite;

        public UpMovingGelState(Gel gel)
        {
            this.gel = gel;
            sprite = EnemySpriteFactory.Instance.createUpMovingGelSprite();
        }
        public void moveLeft()
        {
            gel.CurrentState = new LeftMovingGelState(gel);
        }
        public void moveRight()
        {
            gel.CurrentState = new RightMovingGelState(gel);
        }
        public void moveUp()
        {
            // Blank b/c already moving up
        }
        public void moveDown()
        {
            gel.CurrentState = new DownMovingGelState(gel);
        }

        public void takeDamage()
        {
            this.gel.Health--;
            if (this.gel.Health-- == 0)
            {
                gel.CurrentState.die();
            }
        }
        public void die()
        {
            gel.CurrentState = new DeadGelState(gel);
        }

        public void update()
        {
            gel.currentLocation = new Vector2(gel.currentLocation.X, gel.currentLocation.Y - 3);
            sprite.Update();
        }
    }
}
