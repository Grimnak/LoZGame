using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class UpMovingZolState : IEnemyState
    {
        private readonly Zol zol;
        private readonly IZolSprite sprite;
        
        public UpMovingZolState(Zol zol)
        {
            this.zol = zol;
            this.sprite = EnemySpriteFactory.Instance.CreateZolSprite();
        }

        public void moveLeft()
        {
            this.zol.CurrentState = new LeftMovingZolState(this.zol);
        }

        public void moveRight()
        {
            this.zol.CurrentState = new RightMovingZolState(this.zol);
        }

        public void moveUp()
        {
            // Blank b/c already moving up
        }

        public void moveDown()
        {
            this.zol.CurrentState = new DownMovingZolState(this.zol);
        }

        public void takeDamage()
        {
            this.zol.Health--;
            if (this.zol.Health == 0)
            {
                
                this.zol.CurrentState.die();
            }
        }

        public void die()
        {
            this.zol.CurrentState = new DeadZolState(this.zol);
        }

        public void Update()
        {
            this.zol.currentLocation = new Vector2(this.zol.currentLocation.X, this.zol.currentLocation.Y - 1);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.zol.currentLocation, Color.White);
        }
    }
}
