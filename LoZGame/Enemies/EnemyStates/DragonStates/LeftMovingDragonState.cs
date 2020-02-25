namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LeftMovingDragonState : IEnemyState
    {
        private readonly Dragon dragon;
        private readonly IEnemySprite sprite;

        public LeftMovingDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            this.dragon.VelocityX = -1;
            this.sprite = EnemySpriteFactory.Instance.CreateDragonSprite();
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
            this.dragon.CurrentState = new RightMovingDragonState(this.dragon);
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
            this.dragon.CurrentLocation = new Vector2(this.dragon.CurrentLocation.X + this.dragon.VelocityX, this.dragon.CurrentLocation.Y);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.dragon.CurrentLocation, Color.White);
        }
    }
}