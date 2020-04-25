namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StunnedEnemyState : EnemyStateEssentials, IEnemyState
    {
        private readonly IEnemy enemy;
        private readonly IEnemyState oldState;
        private Vector2 oldVelocity;
        private int stunDuration;

        public StunnedEnemyState(IEnemy enemy, IEnemyState oldState, int stunTime)
        {
            this.oldState = oldState;
            Enemy = enemy;
            oldVelocity = Enemy.Physics.MovementVelocity;
            Enemy.Physics.MovementVelocity = Vector2.Zero;
            stunDuration = stunTime;
            Enemy.CurrentTint = LoZGame.Instance.DefaultTint;
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
                Enemy.CurrentState = oldState;
                Enemy.Physics.MovementVelocity = oldVelocity;
            }
        }

        public override void Draw()
        {
            oldState.Draw();
        }
    }
}