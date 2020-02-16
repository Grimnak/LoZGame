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
            gel.CurrentState = new LeftMovingGelState(gel);
        }
        public void moveRight()
        {
            gel.CurrentState = new RightMovingGelState(gel);
        }
        public void moveUp()
        {
            gel.CurrentState = new UpMovingGelState(gel);
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
                gel.CurrentState.die();
            }
        }
        public void die()
        {

        }

        public void Update()
        {
            gel.currentLocation = new Vector2(gel.currentLocation.X, gel.currentLocation.Y + 3);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, gel.currentLocation, Color.White);
        }
    }
}
