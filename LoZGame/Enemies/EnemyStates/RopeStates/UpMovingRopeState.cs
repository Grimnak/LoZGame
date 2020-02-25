namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingRopeState : IEnemyState
    {
        private readonly Rope rope;
        private readonly IEnemySprite sprite;

        public UpMovingRopeState(Rope rope)
        {
            this.rope = rope;
            this.rope.VelocityX = 0;
            this.rope.VelocityY = -1;
            this.sprite = EnemySpriteFactory.Instance.CreateRightMovingRopeSprite();
        }

        public void MoveLeft()
        {
            this.rope.CurrentState = new LeftMovingRopeState(this.rope);
        }

        public void MoveRight()
        {
            this.rope.CurrentState = new RightMovingRopeState(this.rope);
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
            this.rope.CurrentState = new DownMovingRopeState(this.rope);
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
            this.rope.Health--;
            if (this.rope.Health == 0)
            {
                this.rope.CurrentState.Die();
            }
        }

        public void Die()
        {
            this.rope.CurrentState = new DeadRopeState(this.rope);
        }

        public void Update()
        {
            this.rope.CurrentLocation = new Vector2(this.rope.CurrentLocation.X + this.rope.VelocityX, this.rope.CurrentLocation.Y + this.rope.VelocityY);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.rope.CurrentLocation, Color.White);
        }
    }
}