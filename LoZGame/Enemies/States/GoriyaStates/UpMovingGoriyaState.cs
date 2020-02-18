namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingGoriyaState : IGoriyaState
    {
        private readonly Goriya goriya;
        private readonly IGoriyaSprite sprite;

        public UpMovingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            this.sprite = EnemySpriteFactory.Instance.CreateUpMovingGoriyaSprite();
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
            // Blank b/c already moving down
        }

        public void MoveDown()
        {
            this.goriya.CurrentState = new DownMovingGoriyaState(this.goriya);
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
            this.goriya.CurrentLocation = new Vector2(this.goriya.CurrentLocation.X, this.goriya.CurrentLocation.Y - 1);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.goriya.CurrentLocation, Color.White);
        }
    }
}