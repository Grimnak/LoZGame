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
        private const int fireBallScale = 2;

        public AttackingDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            this.sprite = EnemySpriteFactory.Instance.CreateDragonSprite();
            this.dragon.EntityManager.EnemyProjectileManager.AddFireballs(this.dragon, fireBallScale);
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
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.dragon.currentLocation, Color.White);
        }
    }
}
