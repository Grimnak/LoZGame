using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class UpMovingDodongoState : IEnemyState
    {
        private Dodongo dodongo;
        private IDodongoSprite sprite;

        public UpMovingDodongoState(Dodongo dodongo)
        {
            this.dodongo = dodongo;
            sprite = EnemySpriteFactory.Instance.createUpMovingDodongoSprite();
        }
        public void moveLeft()
        {
            dodongo.CurrentState = new LeftMovingDodongoState(dodongo);
        }
        public void moveRight()
        {
            dodongo.CurrentState = new RightMovingDodongoState(dodongo);
        }
        public void moveUp()
        {
           // Blank b/c already moving up
        }
        public void moveDown()
        {
            dodongo.CurrentState = new DownMovingDodongoState(dodongo);
        }

        public void takeDamage()
        {
            this.dodongo.Health--;
            if (this.dodongo.Health-- == 0)
            {
                dodongo.CurrentState.die();
            }
        }
        public void die()
        {
             dodongo.CurrentState = new DeadDodongoState(dodongo);
        }

        public void update()
        {
            dodongo.currentLocation = new Vector2(dodongo.currentLocation.X, dodongo.currentLocation.Y - 3);
            sprite.Update();
        }
        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, dodongo.currentLocation, Color.White);
        }
    }
}
