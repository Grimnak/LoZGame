using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class DownMovingZolState : IEnemyState
    {
        private Zol zol;
        private IZolSprite sprite;

        public DownMovingZolState(Zol zol)
        {
            this.zol = zol;
            sprite = EnemySpriteFactory.Instance.createZolSprite();
        }
        public void moveLeft()
        {
            zol.CurrentState = new LeftMovingZolState(zol);
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
            // Blank b/c already moving down
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

        public void Update()
        {
            zol.currentLocation = new Vector2(zol.currentLocation.X, zol.currentLocation.Y + 3);
            sprite.Update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, zol.currentLocation, Color.White);
        }
    }
}
