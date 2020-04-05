namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadWallMasterState : IEnemyState
    {
        private readonly WallMaster wallMaster;
        private readonly ISprite sprite;
        private int deathTimer = 0;
        private int deathTimerMax;

        public DeadWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.wallMaster.CurrentState = this;
            this.wallMaster.Physics.Bounds = new Rectangle(wallMaster.Physics.Bounds.Location, Point.Zero);
            LoZGame.Instance.Drops.AttemptDrop(this.wallMaster.Physics.Location);
            deathTimerMax = wallMaster.EnemySpeedData.DeathTimerMax;
            this.wallMaster.Physics.MovementVelocity = Vector2.Zero;
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
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

        public void Die()
        {
        }

        public void Stun(int stunTime)
        {
        }

        public void Update()
        {
            this.deathTimer++;
            this.sprite.Update();
            if (deathTimer >= deathTimerMax)
            {
                this.wallMaster.Expired = true;
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.wallMaster.Physics.Location, this.wallMaster.CurrentTint, this.wallMaster.Physics.Depth);
        }
    }
}
