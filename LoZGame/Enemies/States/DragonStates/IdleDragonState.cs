namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class IdleDragonState : IDragonState
    {
        private readonly Dragon dragon;
        private readonly IDragonSprite sprite;

        public IdleDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            this.sprite = EnemySpriteFactory.Instance.CreateDragonSprite();
        }

        public void MoveLeft()
        {
            this.dragon.CurrentState = new LeftMovingDragonState(this.dragon);
        }

        public void MoveRight()
        {
        }

        public void Stop()
        {
            // Blank b/c already moving left
        }

        public void Attack()
        {
            this.dragon.CurrentState = new AttackingDragonState(this.dragon);
        }

        public void TakeDamage()
        {
            this.dragon.Health--;
            if (this.dragon.Health == 0)
            {
                this.dragon.CurrentState.Die();
            }
        }

        public void Die()
        {
            this.dragon.CurrentState = new DeadDragonState(this.dragon);
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.dragon.CurrentLocation, Color.White);
        }
    }
}