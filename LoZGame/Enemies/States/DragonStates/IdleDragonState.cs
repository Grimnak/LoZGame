using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class IdleDragonState : IDragonState
    {
        private readonly Dragon dragon;
        private readonly IDragonSprite sprite;

        public IdleDragonState(Dragon dragon)
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
            
        }

        public void stop()
        {
            // Blank b/c already moving left
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
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.dragon.currentLocation, Color.White);
        }
    }
}
