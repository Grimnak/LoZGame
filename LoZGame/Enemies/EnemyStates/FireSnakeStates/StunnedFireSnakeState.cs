namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StunnedFireSnakeState : IEnemyState
    {
        private readonly IEnemy fireSnake;
        private readonly IEnemyState oldState;
        private int stunDuration;
        private Vector2 oldVelocity;

        public StunnedFireSnakeState(IEnemy fireSnake, IEnemyState oldState, int stunTime)
        {
            this.oldState = oldState;
            this.fireSnake = fireSnake;
            this.oldVelocity = this.fireSnake.Physics.MovementVelocity;
            this.fireSnake.Physics.MovementVelocity = Vector2.Zero;
            stunDuration = stunTime;
            fireSnake.CurrentTint = LoZGame.Instance.DungeonTint;
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
            this.fireSnake.CurrentState = new DeadFireSnakeState(this.fireSnake);
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
                this.fireSnake.CurrentState = oldState;
                this.fireSnake.Physics.MovementVelocity = oldVelocity;
            }
        }

        public void Draw()
        {
            this.oldState.Draw();
        }
    }
}