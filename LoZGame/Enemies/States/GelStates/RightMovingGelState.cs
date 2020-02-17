using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class RightMovingGelState : IEnemyState
    {
        private readonly Gel gel;
        private readonly IGelSprite sprite;

        public RightMovingGelState(Gel gel)
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
            // Blank b/c already moving right
        }

        public void moveUp()
        {
            this.gel.CurrentState = new UpMovingGelState(this.gel);
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
            this.gel.currentLocation = new Vector2(this.gel.currentLocation.X + 1, this.gel.currentLocation.Y);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.gel.currentLocation, Color.White);
        }
    }
}
