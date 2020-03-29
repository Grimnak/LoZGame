namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StunnedZolState : IEnemyState
    {
        private readonly Zol zol;
        private readonly IEnemyState oldState;
        private Vector2 oldVelocity;
        private int stunDuration;

        public StunnedZolState(Zol zol, IEnemyState oldState, int stunTime)
        {
            this.oldState = oldState;
            this.zol = zol;
            stunDuration = stunTime;
            zol.CurrentTint = LoZGame.Instance.DungeonTint;
            this.oldVelocity = new Vector2(this.zol.Physics.MovementVelocity.X, this.zol.Physics.MovementVelocity.Y);
            this.zol.Physics.MovementVelocity = Vector2.Zero;
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
            this.zol.CurrentState = new DeadZolState(this.zol);
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
                this.zol.CurrentState = oldState;
                this.zol.Physics.MovementVelocity = oldVelocity;
            }
        }

        public void Draw()
        {
            this.oldState.Draw();
        }
    }
}