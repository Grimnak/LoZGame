using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DownMovingDodongoState : IEnemyState
    {
        private Dodongo dodongo;
        private IEnemySprite sprite;

        public DownMovingDodongoState(IEnemy dodongo)
        {
            this.dodongo = (Dodongo)dodongo;
            sprite = EnemySpriteFactory.Instance.createDownMovingDodongoSprite();
        }
        public void moveLeft()
        {
            dodongo.State = new LeftMovingDodongoState(dodongo);
        }
        public void moveRight()
        {
            dodongo.State = new RightMovingDodongoState(dodongo);
        }
        public void moveUp()
        {
            dodongo.State = new UpMovingDodongoState(dodongo);
        }
        public void moveDown()
        {
            // Blank b/c already moving up
        }

        public void takeDamage()
        {
            this.dodongo.Health--;
            if (this.dodongo.Health-- == 0)
            {
                dodongo.currentState.die();
            }
        }
        public void die()
        {
            dodongo.State = new DeadDodongoState(dodongo);
        }

        public void update()
        {
            dodongo.currentLocation = new Vector2(dodongo.currentLocation.X, dodongo.currentLocation.Y + 3);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, dodongo.currentLocation, Color.White);
        }
    }
}
