namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RightMovingRopeState : IEnemyState
    {
        private readonly Rope rope;
        private readonly IRopeSprite sprite;

        public RightMovingRopeState(Rope rope)
        {
            this.rope = rope;
            this.sprite = EnemySpriteFactory.Instance.CreateRightMovingRopeSprite();
        }

        public void MoveLeft()
        {
            this.rope.CurrentState = new LeftMovingRopeState(this.rope);
        }

        public void MoveRight()
        {
            // Blank b/c already moving right
        }

        public void MoveUp()
        {
            this.rope.CurrentState = new UpMovingRopeState(this.rope);
        }

        public void MoveDown()
        {
            this.rope.CurrentState = new DownMovingRopeState(this.rope);
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
            this.rope.CurrentLocation = new Vector2(this.rope.CurrentLocation.X + 2, this.rope.CurrentLocation.Y);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.rope.CurrentLocation, Color.White);
        }
    }
}