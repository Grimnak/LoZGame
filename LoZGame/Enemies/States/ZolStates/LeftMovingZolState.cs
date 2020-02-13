using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class LeftMovingZolState : IEnemyState
    {
        private Zol zol;
        private IZolSprite sprite;

        public LeftMovingZolState(Zol zol)
        {
            this.zol = zol;
            sprite = EnemySpriteFactory.Instance.createLeftMovingZolSprite();
        }
        public void moveLeft()
        {
            // Blank b/c already moving left
        }
        public void moveRight()
        {
            zol.CurrentState = new RightMovingZolState(zol);
        }
        public void moveUp()
        {
            zol.CurrentState = new UpMovingZolState(zol);
        }
        public void moveDown()
        {
            zol.CurrentState = new DownMovingZolState(zol);
        }

        public void takeDamage()
        {
            this.zol.Health--;
            if (this.zol.Health-- == 0)
            {
                zol.CurrentState.die();
            }
        }
        public void die()
        {
            zol.CurrentState = new DeadZolState(zol);
        }

        public void update()
        {
            zol.currentLocation = new Vector2(zol.currentLocation.X - 3, zol.currentLocation.Y);
            sprite.Update();
        }
    }
}
