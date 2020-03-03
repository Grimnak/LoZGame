namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingStalfosState : IEnemyState
    {
        private readonly Stalfos stalfos;
        private readonly ISprite sprite;

        public UpMovingStalfosState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            stalfos.Physics.Velocity = new Vector2(0, -1);
            this.sprite = EnemySpriteFactory.Instance.CreateStalfosSprite();
            this.stalfos.CurrentState = this;
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
            this.stalfos.Physics.Move();
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.stalfos.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}