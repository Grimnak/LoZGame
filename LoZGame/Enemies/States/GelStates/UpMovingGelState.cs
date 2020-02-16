using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class UpMovingGelState : IEnemyState
    {
        private Gel gel;
        private IGelSprite sprite;

        public UpMovingGelState(Gel gel)
        {
            this.gel = gel;
            sprite = EnemySpriteFactory.Instance.createGelSprite();
        }
        public void moveLeft()
        {
            gel.currentState = new LeftMovingGelState(gel);
        }
        public void moveRight()
        {
            gel.currentState = new RightMovingGelState(gel);
        }
        public void moveUp()
        {
            // Blank b/c already moving up
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
            gel.currentLocation = new Vector2(gel.currentLocation.X, gel.currentLocation.Y - 3);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, gel.currentLocation, Color.White);
        }
    }
}
