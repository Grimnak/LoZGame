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
            this.Enemy = enemy;
            this.Enemy.MoveSpeed = GameData.Instance.EnemySpeedData.RopeSpeed;
            this.DirectionChange = GameData.Instance.EnemySpeedData.DirectionChange;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
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