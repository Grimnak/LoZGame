using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class AttackingDragonState : IDragonState
    {
        private readonly Dragon dragon;
        private readonly IDragonSprite sprite;
        private readonly FireballSprite fireballLeft;
        private readonly FireballSprite fireballDownLeft;
        private readonly FireballSprite fireballUpLeft;

        public AttackingDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            this.sprite = EnemySpriteFactory.Instance.CreateDragonSprite();
            this.fireballUpLeft = EnemySpriteFactory.Instance.CreateUpLeftFireballSprite(dragon.currentLocation);
            this.fireballLeft = EnemySpriteFactory.Instance.CreateLeftFireballSprite(dragon.currentLocation);
            this.fireballDownLeft = EnemySpriteFactory.Instance.CreateDownLeftFireballSprite(dragon.currentLocation);
        }

        public void moveLeft()
        {
            this.dragon.CurrentState = new LeftMovingDragonState(this.dragon);
        }

        public void moveRight()
        {
            this.dragon.CurrentState = new RightMovingDragonState(this.dragon);
        }

        public void stop()
        {
            this.dragon.CurrentState = new IdleDragonState(this.dragon);
        }

        public void attack()
        {
            // Blank b/c already attacking
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
            this.fireballDownLeft.Update();
            this.fireballLeft.Update();
            this.fireballUpLeft.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.dragon.currentLocation, Color.White);
            this.fireballDownLeft.Draw(sb, Color.White);
            this.fireballLeft.Draw(sb, Color.White);
            this.fireballUpLeft.Draw(sb, Color.White);
        }
    }
}
