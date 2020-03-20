namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StunnedStalfosState : IEnemyState
    {
        private readonly Stalfos stalfos;
        private readonly IEnemyState oldState;
        private int stunDuration;

        public StunnedStalfosState(Stalfos stalfos, IEnemyState oldState, int stunTime)
        {
            this.oldState = oldState;
            this.stalfos = stalfos;
            stunDuration = stunTime;
            stalfos.CurrentTint = LoZGame.Instance.DungeonTint;
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
            this.stalfos.CurrentState = new DeadStalfosState(this.stalfos);
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
                this.stalfos.CurrentState = oldState;
            }
        }

        public void Draw()
        {
            this.oldState.Draw();
        }
    }
}