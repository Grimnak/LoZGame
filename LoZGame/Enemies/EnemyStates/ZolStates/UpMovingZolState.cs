namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingZolState : IEnemyState
    {
        private readonly Zol zol;
        private readonly IEnemySprite sprite;

        public UpMovingZolState(Zol zol)
        {
            this.zol = zol;
            zol.VelocityX = 0;
            zol.VelocityY = 1;
            this.sprite = EnemySpriteFactory.Instance.CreateZolSprite();
        }

        public void MoveLeft()
        {
            this.zol.CurrentState = new LeftMovingZolState(this.zol);
        }

        public void MoveRight()
        {
            this.zol.CurrentState = new RightMovingZolState(this.zol);
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
            this.zol.CurrentState = new DownMovingZolState(this.zol);
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
            this.zol.Health--;
            if (this.zol.Health == 0)
            {
                this.zol.CurrentState.Die();
            }
        }

        public void Die()
        {
            this.zol.CurrentState = new DeadZolState(this.zol);
        }

        public void Update()
        {
            if (this.zol.ShouldMove)
            {
                this.zol.Physics.Location = new Vector2(this.zol.Physics.Location.X + this.zol.VelocityX, this.zol.Physics.Location.Y + this.zol.VelocityY);
            }
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.zol.Physics.Location, Color.White);
        }
    }
}