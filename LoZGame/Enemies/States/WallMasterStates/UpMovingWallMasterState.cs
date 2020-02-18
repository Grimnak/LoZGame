namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingWallMasterState : IEnemyState
    {
        private readonly WallMaster wallMaster;
        private readonly IEnemySprite sprite;

        public UpMovingWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            this.sprite = EnemySpriteFactory.Instance.CreateLeftMovingWallMasterSprite();
        }

        public void MoveLeft()
        {
            this.wallMaster.CurrentState = new LeftMovingWallMasterState(this.wallMaster);
        }

        public void MoveRight()
        {
            this.wallMaster.CurrentState = new RightMovingWallMasterState(this.wallMaster);
        }

        public void MoveUp()
        {
            // Blank b/c already moving up
        }

        public void MoveDown()
        {
            this.wallMaster.CurrentState = new DownMovingWallMasterState(this.wallMaster);
        }

        public void TakeDamage()
        {
            this.wallMaster.Health--;
            if (this.wallMaster.Health == 0)
            {
                this.wallMaster.CurrentState.Die();
            }
        }

        public void Die()
        {
            this.wallMaster.CurrentState = new DeadWallMasterState(this.wallMaster);
        }

        public void Update()
        {
            this.wallMaster.CurrentLocation = new Vector2(this.wallMaster.CurrentLocation.X, this.wallMaster.CurrentLocation.Y - 1);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.wallMaster.CurrentLocation, Color.White);
        }
    }
}