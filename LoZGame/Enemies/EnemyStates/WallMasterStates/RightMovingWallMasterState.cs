namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RightMovingWallMasterState : IEnemyState
    {
        private readonly WallMaster wallMaster;
        private readonly ISprite sprite;

        public RightMovingWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            wallMaster.VelocityX = 1;
            wallMaster.VelocityY = 0;
            this.sprite = EnemySpriteFactory.Instance.CreateRightMovingWallMasterSprite();
            this.wallMaster.CurrentState = this;
        }

        public void MoveLeft()
        {
            this.wallMaster.CurrentState = new LeftMovingWallMasterState(this.wallMaster);
        }

        public void MoveRight()
        {
        }

        public void MoveUp()
        {
            this.wallMaster.CurrentState = new UpMovingWallMasterState(this.wallMaster);
        }

        public void MoveDown()
        {
            this.wallMaster.CurrentState = new DownMovingWallMasterState(this.wallMaster);
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

        public void TakeDamage(int damageAmount)
        {
            this.wallMaster.Health.DamageHealth(damageAmount);
        }

        public void Die()
        {
            this.wallMaster.CurrentState = new DeadWallMasterState(this.wallMaster);
        }

        public void Update()
        {
            this.wallMaster.Physics.Location = new Vector2(this.wallMaster.Physics.Location.X + this.wallMaster.VelocityX, this.wallMaster.Physics.Location.Y + this.wallMaster.VelocityY);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.wallMaster.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}