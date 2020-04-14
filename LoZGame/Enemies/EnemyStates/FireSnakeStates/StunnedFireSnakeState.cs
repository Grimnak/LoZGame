namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StunnedFireSnakeState : FireSnakeEssentials, IEnemyState
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
            fireSnake.CurrentTint = LoZGame.Instance.DefaultTint;
        }

        public override void Stun(int stunTime)
        {
            stunDuration = stunTime;
        }

        public override void Update()
        {
            stunDuration--;
            if (stunDuration <= 0)
            {
                this.fireSnake.CurrentState = oldState;
                this.fireSnake.Physics.MovementVelocity = oldVelocity;
            }
        }

        public override void Draw()
        {
            this.oldState.Draw();
        }
    }
}