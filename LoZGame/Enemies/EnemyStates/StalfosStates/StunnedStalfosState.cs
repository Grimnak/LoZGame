namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StunnedStalfosState : IEnemyState
    {
        private readonly Stalfos stalfos;
        private readonly IEnemyState oldState;
        private Vector2 oldVelocity;
        private int stunDuration;

        public StunnedStalfosState(Stalfos stalfos, IEnemyState oldState, int stunTime)
        {
            this.oldState = oldState;
            this.stalfos = stalfos;
            this.oldVelocity = this.stalfos.Physics.MovementVelocity;
            this.stalfos.Physics.MovementVelocity = Vector2.Zero;
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
                this.stalfos.Physics.MovementVelocity = oldVelocity;
            }
        }

        public void Draw()
        {
            this.oldState.Draw();
        }
    }
}