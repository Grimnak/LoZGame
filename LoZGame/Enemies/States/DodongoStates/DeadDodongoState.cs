using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class DeadDodongoState : IEnemyState
    {
        private Dodongo dodongo;
        private IDodongoSprite sprite;

        public DeadDodongoState(Dodongo dodongo)
        {
            sprite = EnemySpriteFactory.Instance.createDeadDodongoSprite();
            this.dodongo = null;
        }
        public void moveLeft()
        {
            dodongo.currentState = new LeftMovingDodongoState(dodongo);
        }
        public void moveRight()
        {
            dodongo.currentState = new RightMovingDodongoState(dodongo);
        }
        public void moveUp()
        {
            dodongo.currentState = new UpMovingDodongoState(dodongo);
        }
        public void moveDown()
        {
            dodongo.currentState = new DownMovingDodongoState(dodongo);
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

        }

        public void update()
        {
            dodongo.currentLocation = new Vector2(dodongo.currentLocation.X, dodongo.currentLocation.Y - 3);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, dodongo.currentLocation, Color.White);
        }

    }
}
