namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RightMovingStalfosState : IEnemyState
    {
        private readonly Stalfos stalfos;
        private readonly ISprite sprite;

        public RightMovingStalfosState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            stalfos.VelocityX = 1;
            stalfos.VelocityY = 0;
            this.sprite = EnemySpriteFactory.Instance.CreateStalfosSprite();
            this.stalfos.CurrentState = this;
        }

        public void MoveLeft()
        {
            this.stalfos.CurrentState = new LeftMovingStalfosState(this.stalfos);
        }

        public void MoveRight()
        {
        }

        public void MoveUp()
        {
            this.stalfos.CurrentState = new UpMovingStalfosState(this.stalfos);
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

        public void TakeDamage(int damageAmount)
        {
            this.stalfos.Health.DamageHealth(damageAmount);
        }

        public void Die()
        {
            this.stalfos.CurrentState = new DeadStalfosState(this.stalfos);
        }

        public void Update()
        {
            this.stalfos.Physics.Location = new Vector2(this.stalfos.Physics.Location.X + this.stalfos.VelocityX, this.stalfos.Physics.Location.Y + this.stalfos.VelocityY);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.stalfos.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}