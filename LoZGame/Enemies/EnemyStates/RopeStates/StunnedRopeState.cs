namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StunnedRopeState : RopeEssentials, IEnemyState
    {
        private readonly IEnemy enemy;
        private readonly IEnemyState oldState;
        private Vector2 oldVelocity;
        private int stunDuration;

        public StunnedRopeState(IEnemy enemy, IEnemyState oldState, int stunTime)
        {
            this.oldState = oldState;
            this.Enemy = enemy;
            this.oldVelocity = this.Enemy.Physics.MovementVelocity;
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
            stunDuration = stunTime;
            this.Enemy.CurrentTint = LoZGame.Instance.DefaultTint;
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
                this.Enemy.CurrentState = this.oldState;
                this.Enemy.Physics.MovementVelocity = this.oldVelocity;
            }
        }

        public override void Draw()
        {
            this.oldState.Draw();
        }
    }
}