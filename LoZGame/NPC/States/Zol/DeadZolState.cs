using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class DeadZolState : IEnemyState
    {
        private Zol zol;
        private IZolSprite sprite;

        public DeadZolState(Zol zol)
        {
            this.zol = zol;
            sprite = EnemySpriteFactory.Instance.createDeadZolSprite();
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
