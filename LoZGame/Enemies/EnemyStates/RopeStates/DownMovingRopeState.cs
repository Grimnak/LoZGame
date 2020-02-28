namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DownMovingRopeState : IEnemyState
    {
        private readonly Rope rope;
        private readonly IEnemySprite sprite;

        public DownMovingRopeState(Rope rope)
        {
            this.rope = rope;
            this.rope.VelocityX = 0;
            this.rope.VelocityY = 1;
            this.sprite = EnemySpriteFactory.Instance.CreateLeftMovingRopeSprite();
            this.rope.CurrentState = this;
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
            this.rope.CurrentState = new UpMovingRopeState(this.rope);
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
            this.rope.Physics.Location = new Vector2(this.rope.Physics.Location.X + this.rope.VelocityX, this.rope.Physics.Location.Y + this.rope.VelocityY);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.rope.Physics.Location, Color.White);
        }
    }
}