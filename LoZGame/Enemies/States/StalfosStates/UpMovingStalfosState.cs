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
            sprite = EnemySpriteFactory.Instance.createUpMovingStalfosSprite();
        }
        public void moveLeft()
        {
            stalfos.CurrentState = new LeftMovingStalfosState(stalfos);
        }
        public void moveRight()
        {
            stalfos.CurrentState = new RightMovingStalfosState(stalfos);
        }
        public void moveUp()
        {
            // Blank b/c already moving up
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

        public void update()
        {
            stalfos.currentLocation = new Vector2(stalfos.currentLocation.X, stalfos.currentLocation.Y - 3);
            sprite.Update();
        }
    }
}
