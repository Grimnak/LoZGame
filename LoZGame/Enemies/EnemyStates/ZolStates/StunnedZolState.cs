namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StunnedZolState : ZolEssentials, IEnemyState
    {
        private readonly IEnemy enemy;
        private readonly IEnemyState oldState;
        private Vector2 oldVelocity;
        private int stunDuration;

        public StunnedZolState(IEnemy enemy, IEnemyState oldState, int stunTime)
        {
            this.oldState = oldState;
            this.Enemy = enemy;
            stunDuration = stunTime;
            this.Enemy.CurrentTint = LoZGame.Instance.DungeonTint;
            this.oldVelocity = new Vector2(this.Enemy.Physics.MovementVelocity.X, this.Enemy.Physics.MovementVelocity.Y);
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