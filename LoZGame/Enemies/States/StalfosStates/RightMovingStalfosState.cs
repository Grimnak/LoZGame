using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class RightMovingStalfosState : IEnemyState
    {
        private Stalfos stalfos;
        private IStalfosSprite sprite;

        public RightMovingStalfosState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            sprite = EnemySpriteFactory.Instance.createStalfosSprite();
        }
        public void moveLeft()
        {
            stalfos.currentState = new LeftMovingStalfosState(stalfos);
        }
        public void moveRight()
        {
            // Blank b/c already moving right
        }
        public void moveUp()
        {
            stalfos.currentState = new UpMovingStalfosState(stalfos);
        }
        public void moveDown()
        {
            stalfos.currentState = new DownMovingStalfosState(stalfos);
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
            stalfos.currentState = new DeadStalfosState(stalfos);
        }

        public void update()
        {
            stalfos.currentLocation = new Vector2(stalfos.currentLocation.X + 3, stalfos.currentLocation.Y);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, stalfos.currentLocation, Color.White);
        }
    }
}
