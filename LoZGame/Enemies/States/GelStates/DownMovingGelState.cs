using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DownMovingGelState : IEnemyState
    {
        private readonly Gel gel;
        private readonly IGelSprite sprite;

        public DownMovingGelState(Gel gel)
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
            this.gel.CurrentState = new UpMovingGelState(this.gel);
        }

        public void moveDown()
        {
            // Blank b/c already moving down
        }

        public void takeDamage()
        {
            this.gel.Health--;
            if (this.gel.Health-- == 0)
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
            this.gel.currentLocation = new Vector2(this.gel.currentLocation.X, this.gel.currentLocation.Y + 1);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.gel.currentLocation, Color.White);
        }
    }
}
