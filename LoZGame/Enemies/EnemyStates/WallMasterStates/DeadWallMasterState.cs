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

        public void Draw()
        {
            this.sprite.Draw(this.wallMaster.Physics.Location, Color.White);
        }
    }
}