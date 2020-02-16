using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class LeftMovingDodongoState : IEnemyState
    {
        private Dodongo dodongo;
        private IDodongoSprite sprite;
        int health;

        public LeftMovingDodongoState(Dodongo dodongo)
        {
            this.dodongo = dodongo;
            sprite = EnemySpriteFactory.Instance.createLeftMovingDodongoSprite();
        }
        public void moveLeft()
        {
            // Blank b/c already moving left
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
            dodongo.currentState = new DeadDodongoState(dodongo);
        }

        public void update()
        {
            dodongo.currentLocation = new Vector2(dodongo.currentLocation.X - 3, dodongo.currentLocation.Y);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, dodongo.currentLocation, Color.White);
        }
    }
}
