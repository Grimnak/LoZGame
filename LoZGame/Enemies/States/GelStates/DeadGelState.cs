using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class DeadGelState : IEnemyState
    {
        private Gel gel;
        private IGelSprite sprite;

        public DeadGelState(Gel gel)
        {
            sprite = EnemySpriteFactory.Instance.createDeadGelSprite();
            this.gel = null;
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
            gel.currentState = new UpMovingGelState(gel);
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
                gel.currentState.die();
            }
        }
        public void die()
        {

        }

        public void update()
        {
            gel.currentLocation = new Vector2(gel.currentLocation.X, gel.currentLocation.Y + 3);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, gel.currentLocation, Color.White);
        }
    }
}
