namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LeftMovingDragonState : IDragonState
    {
        private readonly Dragon dragon;
        private readonly IDragonSprite sprite;

        public LeftMovingDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            this.sprite = EnemySpriteFactory.Instance.CreateDragonSprite();
        }

        public void MoveLeft()
        {
            // Blank b/c already moving left
        }

        public void MoveRight()
        {
            this.dragon.CurrentState = new RightMovingDragonState(this.dragon);
        }

        public void Stop()
        {
            this.dragon.CurrentState = new IdleDragonState(this.dragon);
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
            this.dragon.CurrentLocation = new Vector2(this.dragon.CurrentLocation.X - 1, this.dragon.CurrentLocation.Y);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.dragon.CurrentLocation, Color.White);
        }
    }
}