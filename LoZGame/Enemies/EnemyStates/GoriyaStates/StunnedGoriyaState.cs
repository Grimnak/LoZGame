namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StunnedGoriyaState : GoriyaEssentials, IEnemyState
    {
        private readonly IEnemy enemy;
        private readonly IEnemyState oldState;
        private int stunDuration;
        private Vector2 oldVelocity;

        public StunnedGoriyaState(IEnemy enemy, IEnemyState oldState, int stunTime)
        {
            this.oldState = oldState;
            this.Enemy = enemy;
            this.oldVelocity = this.Enemy.Physics.MovementVelocity;
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
            stunDuration = stunTime;
            enemy.CurrentTint = LoZGame.Instance.DungeonTint;
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