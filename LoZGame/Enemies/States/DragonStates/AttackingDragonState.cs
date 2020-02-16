using System;

namespace LoZClone
{
    public class AttackingDragonState : IEnemyState
    {
        private Dragon dragon;
        private IDragonSprite sprite;
        private FireballSprite fireballLeft;
        private FireballSprite fireballDownLeft;
        private FireballSprite fireballUpLeft;

        public AttackingDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            sprite = EnemySpriteFactory.Instance.createAttackingDragonSprite();
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
        public void moveUp()
        {
            dragon.CurrentState = new UpMovingDragonState(dragon);
        }
        public void moveDown()
        {
            dragon.CurrentState = new DownMovingDragonState(dragon);
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

        public void update()
        {         
            sprite.update();
            fireballDownLeft.update();
            fireballLeft.update();
            fireballUpLeft.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, dragon.currentLocation, Color.White);
            fireballDownLeft.draw(sb, Color.White);
            fireballLeft.draw(sb, Color.White);
            fireballUpLeft.draw(sb, Color.White);
        }
    }
}
