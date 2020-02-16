using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
            dodongo.CurrentState = new LeftMovingDodongoState(dodongo);
        }
        public void moveRight()
        {
            // Blank b/c already moving right
        }
        public void moveUp()
        {
            dodongo.CurrentState = new UpMovingDodongoState(dodongo);
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
            // dodongo.CurrentState = new DeadDodongoState(dodongo);
        }

        public void Update()
        {
            dodongo.currentLocation = new Vector2(dodongo.currentLocation.X + 3, dodongo.currentLocation.Y);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, dodongo.currentLocation, Color.White);
        }
    }
}
