namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StunnedWallMasterState : IEnemyState
    {
        private readonly WallMaster wallMaster;
        private readonly IEnemyState oldState;
        private int stunDuration;

        public StunnedWallMasterState(WallMaster wallMaster, IEnemyState oldState, int stunTime)
        {
            this.oldState = oldState;
            this.wallMaster = wallMaster;
            stunDuration = stunTime;
            wallMaster.CurrentTint = LoZGame.Instance.DungeonTint;
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
            this.wallMaster.CurrentState = new DeadWallMasterState(this.wallMaster);
        }

        public void Stun(int stunTime)
        {
            stunDuration = stunTime;
        }

        public void Update()
        {
            stunDuration--;
            if (stunDuration <= 0)
            {
                this.wallMaster.CurrentState = oldState;
            }
        }

        public void Draw()
        {
            this.oldState.Draw();
        }
    }
}