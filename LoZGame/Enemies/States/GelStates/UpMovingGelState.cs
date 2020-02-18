namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingGelState : IEnemyState
    {
        private readonly Gel gel;
        private readonly IEnemySprite sprite;

        public UpMovingGelState(Gel gel)
        {
            this.gel = gel;
            this.sprite = EnemySpriteFactory.Instance.CreateGelSprite();
        }

        public void MoveLeft()
        {
            this.gel.CurrentState = new LeftMovingGelState(this.gel);
        }

        public void MoveRight()
        {
            this.gel.CurrentState = new RightMovingGelState(this.gel);
        }

        public void MoveUp()
        {
            // Blank b/c already moving up
        }

        public void MoveDown()
        {
            this.gel.CurrentState = new DownMovingGelState(this.gel);
        }

        public void TakeDamage()
        {
            this.gel.Health--;
            if (this.gel.Health == 0)
            {
                this.gel.CurrentState.Die();
            }
        }

        public void Die()
        {
            this.gel.CurrentState = new DeadGelState(this.gel);
        }

        public void Update()
        {
            this.gel.CurrentLocation = new Vector2(this.gel.CurrentLocation.X, this.gel.CurrentLocation.Y - 1);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.gel.CurrentLocation, Color.White);
        }
    }
}