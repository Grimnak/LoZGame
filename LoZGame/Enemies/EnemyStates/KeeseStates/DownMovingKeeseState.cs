namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DownMovingKeeseState : IEnemyState
    {
        private readonly Keese keese;
        private readonly IEnemySprite sprite;

        public DownMovingKeeseState(Keese keese)
        {
            this.keese = keese;
            this.keese.VelocityX = 0;
            this.keese.VelocityY = .2 * this.keese.AccelerationCurrent;
            this.sprite = EnemySpriteFactory.Instance.CreateKeeseSprite();
        }

        public void MoveLeft()
        {
            this.keese.CurrentState = new LeftMovingKeeseState(this.keese);
        }

        public void MoveRight()
        {
            this.keese.CurrentState = new RightMovingKeeseState(this.keese);
        }

        public void MoveUp()
        {
            this.keese.CurrentState = new UpMovingKeeseState(this.keese);
        }

        public void MoveDown()
        {
        }

        public void MoveUpLeft()
        {
            this.keese.CurrentState = new UpLeftMovingKeeseState(this.keese);
        }

        public void MoveUpRight()
        {
            this.keese.CurrentState = new UpRightMovingKeeseState(this.keese);
        }

        public void MoveDownLeft()
        {
            this.keese.CurrentState = new DownLeftMovingKeeseState(this.keese);
        }

        public void MoveDownRight()
        {
            this.keese.CurrentState = new DownRightMovingKeeseState(this.keese);
        }

        public void Attack()
        {
        }

        public void Stop()
        {
        }

        public void TakeDamage()
        {
            this.keese.Health--;
            if (this.keese.Health == 0)
            {
                this.keese.CurrentState.Die();
            }
        }

        public void Die()
        {
            this.keese.CurrentState = new DeadKeeseState(this.keese);
        }

        public void Update()
        {
            this.keese.Physics.Location = new Vector2(this.keese.Physics.Location.X + (float)this.keese.VelocityX, this.keese.Physics.Location.Y + (float)this.keese.VelocityY);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.keese.Physics.Location, Color.White);
        }
    }
}