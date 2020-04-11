namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StunnedWallMasterState : WallMasterEssentials, IEnemyState
    {
        private readonly IEnemy enemy;
        private readonly IEnemyState oldState;
        private Vector2 oldVelocity;
        private int stunDuration;

        public StunnedWallMasterState(IEnemy enemy, IEnemyState oldState, int stunTime)
        {
            this.oldState = oldState;
            this.Enemy = enemy;
            stunDuration = stunTime;
            enemy.CurrentTint = LoZGame.Instance.DungeonTint;
            oldVelocity = this.Enemy.Physics.MovementVelocity;
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
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