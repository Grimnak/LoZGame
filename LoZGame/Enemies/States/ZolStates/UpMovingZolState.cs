using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class UpMovingZolState : IEnemyState
    {
        private Zol zol;
        private IZolSprite sprite;
        
        public UpMovingZolState(Zol zol)
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
            // Blank b/c already moving up
        }
        public void moveDown()
        {
            zol.CurrentState = new DownMovingZolState(zol);
        }

        public void takeDamage()
        {
            this.zol.Health--;
            if (this.zol.Health == 0)
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
            zol.currentLocation = new Vector2(zol.currentLocation.X, zol.currentLocation.Y - 1);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, zol.currentLocation, Color.White);
        }
    }
}
