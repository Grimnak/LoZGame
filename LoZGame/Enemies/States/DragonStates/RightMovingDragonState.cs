using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class RightMovingDragonState : IDragonState
    {
        private readonly Dragon dragon;
        private readonly IDragonSprite sprite;

        public RightMovingDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            this.sprite = EnemySpriteFactory.Instance.CreateDragonSprite();
        }

        public void moveLeft()
        {
            this.dragon.CurrentState = new LeftMovingDragonState(this.dragon);
        }

        public void moveRight()
        {
            // Blank b/c already moving right
        }

        public void stop()
        {
            this.dragon.CurrentState = new IdleDragonState(this.dragon);
        }

        public void attack()
        {
            this.dragon.CurrentState = new AttackingDragonState(this.dragon);
        }

        public void takeDamage()
        {
            this.dragon.Health--;
            if (this.dragon.Health == 0)
            {
                this.dragon.CurrentState.die();
            }
        }

        public void die()
        {
            this.dragon.CurrentState = new DeadDragonState(this.dragon);
        }

        public void Update()
        {
            this.dragon.currentLocation = new Vector2(this.dragon.currentLocation.X + 1, this.dragon.currentLocation.Y);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.dragon.currentLocation, Color.White);
        }
    }
}
