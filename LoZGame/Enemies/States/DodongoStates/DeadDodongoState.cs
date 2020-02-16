using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DeadDodongoState : IEnemyState
    {
        private Dodongo dodongo;
        private IDodongoSprite sprite;

        public DeadDodongoState(LoZGame game, Dodongo dodongo)
        {
            sprite = EnemySpriteFactory.Instance.createDeadDodongoSprite();
            this.dodongo = null;
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

        }

        public void Update()
        {
            dodongo.currentLocation = new Vector2(dodongo.currentLocation.X, dodongo.currentLocation.Y - 3);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, dodongo.currentLocation, Color.White);
        }

    }
}
