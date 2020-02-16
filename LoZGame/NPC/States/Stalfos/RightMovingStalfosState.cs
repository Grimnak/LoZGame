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
            stalfos.CurrentState = new LeftMovingStalfosState(stalfos);
        }
        public void moveRight()
        {
            // Blank b/c already moving right
        }
        public void moveUp()
        {
            stalfos.CurrentState = new UpMovingStalfosState(stalfos);
        }
        public void moveDown()
        {
            stalfos.CurrentState = new DownMovingStalfosState(stalfos);
        }

        public void takeDamage()
        {
            this.stalfos.Health--;
            if (this.stalfos.Health-- == 0)
            {
                stalfos.CurrentState.die();
            }
        }
        public void die()
        {
            stalfos.CurrentState = new DeadStalfosState(stalfos);
        }

        public void Update()
        {
            stalfos.currentLocation = new Vector2(stalfos.currentLocation.X + 3, stalfos.currentLocation.Y);
            sprite.Update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, stalfos.currentLocation, Color.White);
        }
    }
}
