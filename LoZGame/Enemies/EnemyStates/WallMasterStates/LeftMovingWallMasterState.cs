namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LeftMovingWallMasterState : IEnemyState
    {
        private readonly WallMaster wallMaster;
        private readonly ISprite sprite;

        public LeftMovingWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            wallMaster.Physics.Velocity = new Vector2(-1, 0);
            this.sprite = EnemySpriteFactory.Instance.CreateLeftMovingWallMasterSprite();
            this.wallMaster.CurrentState = this;
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
            this.wallMaster.CurrentState = new RightMovingWallMasterState(this.wallMaster);
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
            this.wallMaster.Physics.Move();
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.wallMaster.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}