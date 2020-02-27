namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RightMovingRopeState : IEnemyState
    {
        private readonly Rope rope;
        private readonly IEnemySprite sprite;

        public RightMovingRopeState(Rope rope)
        {
            this.rope = rope;
            this.rope.VelocityX = 1 * rope.AttackFactor;
            this.rope.VelocityY = 0 * rope.AttackFactor;
            this.sprite = EnemySpriteFactory.Instance.CreateRightMovingRopeSprite();
        }

        public void MoveLeft()
        {
            this.rope.CurrentState = new LeftMovingRopeState(this.rope);
        }

        public void MoveRight()
        {
        }

        public void MoveUp()
        {
            this.rope.CurrentState = new UpMovingRopeState(this.rope);
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
            this.rope.CurrentLocation = new Vector2(this.rope.CurrentLocation.X + this.rope.VelocityX, this.rope.CurrentLocation.Y + this.rope.VelocityX);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.rope.CurrentLocation, Color.White);
        }
    }
}