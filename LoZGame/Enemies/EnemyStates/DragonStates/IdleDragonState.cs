namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class IdleDragonState : IEnemyState
    {
        private readonly Dragon dragon;
        private readonly ISprite sprite;

        public IdleDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            this.dragon.Physics.ResetVelocity();
            this.sprite = EnemySpriteFactory.Instance.CreateDragonSprite();
            this.dragon.CurrentState = this;
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
            this.dragon.CurrentState = new LeftMovingDragonState(this.dragon);
        }

        public void MoveRight()
        {
        }

        public void MoveUpLeft()
        {
        }

        public void MoveUpRight()
        {
        }

        public void MoveDownLeft()
        {
        }

        public void MoveDownRight()
        {
        }

        public void Stop()
        {
        }

        public void Attack()
        {
            this.dragon.CurrentState = new AttackingDragonState(this.dragon);
        }

        public void TakeDamage(int damageAmount)
        {
            this.dragon.Health.DamageHealth(damageAmount);
        }

        public void Die()
        {
            this.dragon.CurrentState = new DeadDragonState(this.dragon);
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.dragon.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}