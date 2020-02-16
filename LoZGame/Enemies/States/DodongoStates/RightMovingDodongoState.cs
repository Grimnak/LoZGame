using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class RightMovingDodongoState : IEnemyState
    {
        private Dodongo dodongo;
        private IDodongoSprite sprite;

        public RightMovingDodongoState(Dodongo dodongo)
        {
            this.dodongo = dodongo;
            sprite = EnemySpriteFactory.Instance.createRightMovingDodongoSprite();
        }
        public void moveLeft()
        {
            dodongo.currentState = new LeftMovingDodongoState(dodongo);
        }
        public void moveRight()
        {
            // Blank b/c already moving right
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
            dodongo.currentState = new DeadDodongoState(dodongo);
        }

        public void update()
        {
            dodongo.currentLocation = new Vector2(dodongo.currentLocation.X + 3, dodongo.currentLocation.Y);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, dodongo.currentLocation, Color.White);
        }
    }
}
