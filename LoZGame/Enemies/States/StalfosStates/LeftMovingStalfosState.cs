using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class LeftMovingStalfosState : IEnemyState
    {
        private Stalfos stalfos;
        private IStalfosSprite sprite;

        public LeftMovingStalfosState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            sprite = EnemySpriteFactory.Instance.createStalfosSprite();
        }
        public void moveLeft()
        {
            // Blank b/c already moving left
        }
        public void moveRight()
        {
            stalfos.CurrentState = new RightMovingStalfosState(stalfos);
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
            if (this.stalfos.Health == 0)
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
            stalfos.currentLocation = new Vector2(stalfos.currentLocation.X - 1, stalfos.currentLocation.Y);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, stalfos.currentLocation, Color.White);
        }
    }
}
