using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class UpMovingGelState : IEnemyState
    {
        private readonly Gel gel;
        private readonly IGelSprite sprite;

        public UpMovingGelState(Gel gel)
        {
            this.gel = gel;
            this.sprite = EnemySpriteFactory.Instance.CreateGelSprite();
        }

        public void moveLeft()
        {
            this.gel.CurrentState = new LeftMovingGelState(this.gel);
        }

        public void moveRight()
        {
            this.gel.CurrentState = new RightMovingGelState(this.gel);
        }

        public void moveUp()
        {
            // Blank b/c already moving up
        }

        public void moveDown()
        {
            this.gel.CurrentState = new DownMovingGelState(this.gel);
        }

        public void takeDamage()
        {
            this.gel.Health--;
            if (this.gel.Health == 0)
            {
                this.gel.CurrentState.die();
            }
        }

        public void die()
        {
            this.gel.CurrentState = new DeadGelState(this.gel);
        }

        public void Update()
        {
            this.gel.currentLocation = new Vector2(this.gel.currentLocation.X, this.gel.currentLocation.Y - 1);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.gel.currentLocation, Color.White);
        }
    }
}
