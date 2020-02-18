namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RightMovingWallMasterState : IEnemyState
    {
        private readonly WallMaster wallMaster;
        private readonly IEnemySprite sprite;

        public RightMovingWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            this.sprite = EnemySpriteFactory.Instance.CreateRightMovingWallMasterSprite();
        }

        public void MoveLeft()
        {
            this.wallMaster.CurrentState = new LeftMovingWallMasterState(this.wallMaster);
        }

        public void MoveRight()
        {
            // Blank b/c already moving right
        }

        public void MoveUp()
        {
            this.wallMaster.CurrentState = new UpMovingWallMasterState(this.wallMaster);
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
            this.wallMaster.CurrentLocation = new Vector2(this.wallMaster.CurrentLocation.X + 1, this.wallMaster.CurrentLocation.Y);
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.wallMaster.CurrentLocation, Color.White);
        }
    }
}