namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StunnedGoriyaState : IEnemyState
    {
        private readonly Goriya goriya;
        private readonly IEnemyState oldState;
        private int stunDuration;
        private Vector2 oldVelocity;

        public StunnedGoriyaState(Goriya goriya, IEnemyState oldState, int stunTime)
        {
            this.oldState = oldState;
            this.oldVelocity = this.goriya.Physics.MovementVelocity;
            this.goriya.Physics.MovementVelocity = Vector2.Zero;
            this.goriya = goriya;
            stunDuration = stunTime;
            goriya.CurrentTint = LoZGame.Instance.DungeonTint;
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
            this.goriya.CurrentState = new DeadGoriyaState(this.goriya);
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
                this.goriya.CurrentState = oldState;
                this.goriya.Physics.MovementVelocity = oldVelocity;
            }
        }

        public void Draw()
        {
            this.oldState.Draw();
        }
    }
}