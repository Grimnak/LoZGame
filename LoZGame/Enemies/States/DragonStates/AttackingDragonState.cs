using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class AttackingDragonState : IDragonState
    {
        private Dragon dragon;
        private IDragonSprite sprite;
        private FireballSprite fireballLeft;
        private FireballSprite fireballDownLeft;
        private FireballSprite fireballUpLeft;

        public AttackingDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            sprite = EnemySpriteFactory.Instance.createDragonSprite();
            fireballUpLeft = EnemySpriteFactory.Instance.createUpLeftFireballSprite();
            fireballLeft = EnemySpriteFactory.Instance.createLeftFireballSprite();
            fireballDownLeft = EnemySpriteFactory.Instance.createDownLeftFireballSprite();
        }
        public void moveLeft()
        {
            dragon.CurrentState = new LeftMovingDragonState(dragon);
        }
        public void moveRight()
        {
            dragon.CurrentState = new RightMovingDragonState(dragon);
        }

        public void stop()
        {
            dragon.CurrentState = new IdleDragonState(dragon);
        }
        public void attack()
        {
            // Blank b/c already attacking
        }

        public void takeDamage()
        {
            this.dragon.Health--;
            if (this.dragon.Health-- == 0)
            {
                dragon.CurrentState.die();
            }
        }
        public void die()
        {
            dragon.CurrentState = new DeadDragonState(dragon);
        }

        public void Update()
        {         
            sprite.Update();
            fireballDownLeft.Update();
            fireballLeft.Update();
            fireballUpLeft.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, dragon.currentLocation, Color.White);
            fireballDownLeft.Draw(sb, Color.White);
            fireballLeft.Draw(sb, Color.White);
            fireballUpLeft.Draw(sb, Color.White);
        }
    }
}
