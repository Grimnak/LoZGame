namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LeftMovingGelState : IEnemyState
    {
        private readonly Gel gel;
        private readonly IGelSprite sprite;

        public LeftMovingGelState(Gel gel)
        {
            this.gel = gel;
            this.sprite = EnemySpriteFactory.Instance.CreateGelSprite();
        }

        public void MoveLeft()
        {
            // Blank b/c already moving left
        }

        public void MoveRight()
        {
            this.gel.CurrentState = new RightMovingGelState(this.gel);
        }

        public void MoveUp()
        {
            this.gel.CurrentState = new UpMovingGelState(this.gel);
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
            this.gel.CurrentLocation = new Vector2(this.gel.CurrentLocation.X - 1, this.gel.CurrentLocation.Y);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.gel.CurrentLocation, Color.White);
        }
    }
}