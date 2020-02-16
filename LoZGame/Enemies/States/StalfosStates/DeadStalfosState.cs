using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class DeadStalfosState : IEnemyState
    {
        private Stalfos stalfos;
        private IStalfosSprite sprite;

        public DeadStalfosState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            sprite = EnemySpriteFactory.Instance.createDeadStalfosSprite();
        }
        public void moveLeft()
        {
            stalfos.currentState = new LeftMovingStalfosState(stalfos);
        }
        public void moveRight()
        {
            stalfos.currentState = new RightMovingStalfosState(stalfos);
        }
        public void moveUp()
        {
            stalfos.currentState = new UpMovingStalfosState(stalfos);
        }
        public void moveDown()
        {
            // Blank b/c already moving down
        }

        public void takeDamage()
        {
            this.stalfos.Health--;
            if (this.stalfos.Health-- == 0)
            {
                stalfos.currentState.die();
            }
        }
        public void die()
        {

        }

        public void update()
        {
            stalfos.currentLocation = new Vector2(stalfos.currentLocation.X, stalfos.currentLocation.Y + 3);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, stalfos.currentLocation, Color.White);
        }
    }
}
