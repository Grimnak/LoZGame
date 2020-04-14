namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StunnedStalfosState : StalfosEssentials, IEnemyState
    {
        private readonly IEnemy enemy;
        private readonly IEnemyState oldState;
        private Vector2 oldVelocity;
        private int stunDuration;

        public StunnedStalfosState(IEnemy enemy, IEnemyState oldState, int stunTime)
        {
            this.oldState = oldState;
            this.Enemy = enemy;
            this.oldVelocity = this.Enemy.Physics.MovementVelocity;
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
            stunDuration = stunTime;
            this.Enemy.CurrentTint = LoZGame.Instance.DefaultTint;
        }

        public new void Stun(int stunTime)
        {
            stunDuration = stunTime;
        }

        public override void Update()
        {
            stunDuration--;
            if (stunDuration <= 0)
            {
                this.Enemy.CurrentState = oldState;
                this.Enemy.Physics.MovementVelocity = oldVelocity;
            }
        }

        public override void Draw()
        {
            this.oldState.Draw();
        }
    }
}