namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpMovingWallMasterState : IEnemyState
    {
        private readonly WallMaster wallMaster;
        private readonly ISprite sprite;
        private RandomStateGenerator randomStateGenerator;
        private int lifeTime = 0;
        private int directionChange;

        public UpMovingWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            this.directionChange = this.wallMaster.EnemySpeedData.DirectionChange;
            this.sprite = EnemySpriteFactory.Instance.CreateLeftMovingWallMasterSprite();
            this.wallMaster.CurrentState = this;
            this.randomStateGenerator = new RandomStateGenerator(this.wallMaster, 2, 6);
            this.wallMaster.Physics.MovementVelocity = new Vector2(0, -1 * this.wallMaster.MoveSpeed);
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

        public void Stun(int stunTime)
        {
            this.wallMaster.CurrentState = new StunnedWallMasterState(this.wallMaster, this, stunTime);
        }

        public void Update()
        {
            this.lifeTime++;
            if (this.lifeTime > this.directionChange)
            {
                randomStateGenerator.Update();
                this.lifeTime = 0;
            }
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.wallMaster.Physics.Location, this.wallMaster.CurrentTint, this.wallMaster.Physics.Depth);
        }
    }
}