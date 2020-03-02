namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RightMovingGoriyaState : IEnemyState
    {
        private readonly Goriya goriya;
        private readonly ISprite sprite;

        public RightMovingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            this.goriya.VelocityX = 1;
            this.goriya.VelocityY = 0;
            this.sprite = EnemySpriteFactory.Instance.CreateRightMovingGoriyaSprite();
            this.goriya.CurrentState = this;
        }

        public void MoveLeft()
        {
            this.goriya.CurrentState = new LeftMovingGoriyaState(this.goriya);
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

        public void MoveUp()
        {
            this.goriya.CurrentState = new UpMovingGoriyaState(this.goriya);
        }

        public void MoveDown()
        {
            this.goriya.CurrentState = new DownMovingGoriyaState(this.goriya);
        }

        public void Attack()
        {
            this.goriya.CurrentState = new AttackingGoriyaState(this.goriya);
        }

        public void TakeDamage(int damageAmount)
        {
            this.goriya.Health.DamageHealth(damageAmount);
        }

        public void Die()
        {
            this.goriya.CurrentState = new DeadGoriyaState(this.goriya);
        }

        public void Update()
        {
            this.goriya.Physics.Location = new Vector2(this.goriya.Physics.Location.X + this.goriya.VelocityX, this.goriya.Physics.Location.Y + this.goriya.VelocityY);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.goriya.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}