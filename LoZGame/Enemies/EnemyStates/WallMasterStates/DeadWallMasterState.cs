namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadWallMasterState : IEnemyState
    {
        private readonly WallMaster wallMaster;
        private readonly DeadEnemySprite sprite;

        public DeadWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.wallMaster.VelocityX = 0;
            this.wallMaster.VelocityY = 0;
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

        public void TakeDamage()
        {
        }

        public void Die()
        {
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.wallMaster.CurrentLocation, Color.White);
        }
    }
}