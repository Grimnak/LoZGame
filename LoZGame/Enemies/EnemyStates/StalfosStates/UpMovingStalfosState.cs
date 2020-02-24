namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingStalfosState : IEnemyState
    {
        private readonly Stalfos stalfos;
        private readonly IEnemySprite sprite;

        public UpMovingStalfosState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            stalfos.VelocityX = 0;
            stalfos.VelocityY = -1;
            this.sprite = EnemySpriteFactory.Instance.CreateStalfosSprite();
        }

        public void MoveLeft()
        {
            this.stalfos.CurrentState = new LeftMovingStalfosState(this.stalfos);
        }

        public void MoveRight()
        {
            this.stalfos.CurrentState = new RightMovingStalfosState(this.stalfos);
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
            this.stalfos.CurrentState = new DownMovingStalfosState(this.stalfos);
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

        public void Attack()
        {
        }

        public void Stop()
        {
        }

        public void TakeDamage()
        {
            this.stalfos.Health--;
            if (this.stalfos.Health == 0)
            {
                this.stalfos.CurrentState.Die();
            }
        }

        public void Die()
        {
            this.stalfos.CurrentState = new DeadStalfosState(this.stalfos);
        }

        public void Update()
        {
            this.stalfos.CurrentLocation = new Vector2(this.stalfos.CurrentLocation.X + this.stalfos.VelocityX, this.stalfos.CurrentLocation.Y + this.stalfos.VelocityY);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.stalfos.CurrentLocation, Color.White);
        }
    }
}