namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DownMovingGoriyaState : IEnemyState
    {
        private readonly Goriya goriya;
        private readonly IEnemySprite sprite;

        public DownMovingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            this.goriya.VelocityX = 0;
            this.goriya.VelocityY = 1;
            this.sprite = EnemySpriteFactory.Instance.CreateDownMovingGoriyaSprite();
            this.goriya.CurrentState = this;
        }

        public void MoveLeft()
        {
            this.goriya.CurrentState = new LeftMovingGoriyaState(this.goriya);
        }

        public void MoveRight()
        {
            this.goriya.CurrentState = new RightMovingGoriyaState(this.goriya);
        }

        public void MoveUp()
        {
            this.goriya.CurrentState = new UpMovingGoriyaState(this.goriya);
        }

        public void MoveDown()
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
            this.goriya.CurrentState = new AttackingGoriyaState(this.goriya);
        }

        public void TakeDamage()
        {
            this.goriya.Health--;
            if (this.goriya.Health == 0)
            {
                this.goriya.CurrentState.Die();
            }
        }

        public void Die()
        {
            this.goriya.CurrentState = new DeadGoriyaState(this.goriya);
        }

        public void Update()
        {
            this.goriya.CurrentLocation = new Vector2(this.goriya.CurrentLocation.X + this.goriya.VelocityX, this.goriya.CurrentLocation.Y + this.goriya.VelocityY);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.goriya.CurrentLocation, Color.White);
        }
    }
}