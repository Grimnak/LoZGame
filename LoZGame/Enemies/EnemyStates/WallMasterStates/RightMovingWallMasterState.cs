namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RightMovingWallMasterState : IEnemyState
    {
        private readonly WallMaster wallMaster;
        private readonly ISprite sprite;
        private RandomStateGenerator randomStateGenerator;
        private int lifeTime = 0;
        private readonly int directionChange = 40;

        public RightMovingWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            this.sprite = EnemySpriteFactory.Instance.CreateRightMovingWallMasterSprite();
            this.wallMaster.CurrentState = this;
            this.randomStateGenerator = new RandomStateGenerator(this.wallMaster, 2, 6);
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
            this.wallMaster.CurrentState = new AttackingWallMasterState(this.wallMaster);

        }

        public void Stop()
        {
        }

        public void Die()
        {
            this.wallMaster.CurrentState = new DeadWallMasterState(this.wallMaster);
        }

        public void Update()
        {
            this.lifeTime++;
            if (this.lifeTime > this.directionChange)
            {
                randomStateGenerator.Update();
                this.lifeTime = 0;
            }
            this.wallMaster.Physics.Location = new Vector2(this.wallMaster.Physics.Location.X + this.wallMaster.MoveSpeed, this.wallMaster.Physics.Location.Y);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.wallMaster.Physics.Location, this.wallMaster.CurrentTint);
        }
    }
}