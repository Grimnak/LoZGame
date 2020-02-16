using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class UpMovingStalfosState : IEnemyState
    {
        private Stalfos stalfos;
        private IStalfosSprite sprite;

        public UpMovingStalfosState(Stalfos stalfos)
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
            stalfos.currentState = new RightMovingStalfosState(stalfos);
        }
        public void moveUp()
        {
            // Blank b/c already moving up
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
            stalfos.currentLocation = new Vector2(stalfos.currentLocation.X, stalfos.currentLocation.Y - 3);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, stalfos.currentLocation, Color.White);
        }
    }
}
