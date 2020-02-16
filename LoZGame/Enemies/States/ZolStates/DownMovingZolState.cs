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
            zol.currentState = new LeftMovingZolState(zol);
        }
        public void moveRight()
        {
            zol.currentState = new RightMovingZolState(zol);
        }
        public void moveUp()
        {
            zol.currentState = new UpMovingZolState(zol);
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
                zol.currentState.die();
            }
        }
        public void die()
        {
            zol.currentState = new DeadZolState(zol);
        }

        public void update()
        {
            zol.currentLocation = new Vector2(zol.currentLocation.X, zol.currentLocation.Y + 3);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, zol.currentLocation, Color.White);
        }
    }
}
