using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class LeftMovingGelState : IEnemyState
    {
        private Gel gel;
        private IGelSprite sprite;

        public LeftMovingGelState(Gel gel)
        {
            this.gel = gel;
            sprite = EnemySpriteFactory.Instance.createGelSprite();
        }
        public void moveLeft()
        {
            // Blank b/c already moving left
        }
        public void moveRight()
        {
            gel.currentState = new RightMovingGelState(gel);
        }
        public void moveUp()
        {
            gel.currentState = new UpMovingGelState(gel);
        }
        public void moveDown()
        {
            gel.currentState = new DownMovingGelState(gel);
        }

        public void takeDamage()
        {
            this.gel.Health--;
            if (this.gel.Health-- == 0)
            {
                gel.currentState.die();
            }
        }
        public void die()
        {
            gel.currentState = new DeadGelState(gel);
        }

        public void update()
        {
            gel.currentLocation = new Vector2(gel.currentLocation.X - 3, gel.currentLocation.Y);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, gel.currentLocation, Color.White);
        }
    }
}
