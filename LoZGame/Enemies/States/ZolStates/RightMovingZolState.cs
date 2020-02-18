namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RightMovingZolState : IEnemyState
    {
        private readonly Zol zol;
        private readonly IZolSprite sprite;

        public RightMovingZolState(Zol zol)
        {
            this.zol = zol;
            this.sprite = EnemySpriteFactory.Instance.CreateZolSprite();
        }

        public void MoveLeft()
        {
            this.zol.CurrentState = new LeftMovingZolState(this.zol);
        }

        public void MoveRight()
        {
            // Blank b/c already moving right
        }

        public void MoveUp()
        {
            this.zol.CurrentState = new UpMovingZolState(this.zol);
        }

        public void MoveDown()
        {
            this.zol.CurrentState = new DownMovingZolState(this.zol);
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
            this.zol.CurrentLocation = new Vector2(this.zol.CurrentLocation.X + 1, this.zol.CurrentLocation.Y);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.zol.CurrentLocation, Color.White);
        }
    }
}