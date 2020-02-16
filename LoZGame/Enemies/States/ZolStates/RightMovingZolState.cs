using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class RightMovingZolState : IEnemyState
    {
        private Zol zol;
        private IZolSprite sprite;

        public RightMovingZolState(Zol zol)
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
            // Blank b/c already moving right
        }
        public void moveUp()
        {
            zol.currentState = new UpMovingZolState(zol);
        }
        public void moveDown()
        {
            zol.currentState = new DownMovingZolState(zol);
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
            zol.currentLocation = new Vector2(zol.currentLocation.X + 3, zol.currentLocation.Y);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, zol.currentLocation, Color.White);
        }
    }
}
