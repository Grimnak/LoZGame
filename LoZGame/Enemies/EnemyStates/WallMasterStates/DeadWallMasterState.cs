namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadWallMasterState : WallMasterEssentials, IEnemyState
    {
        private readonly IEnemy enemy;
        private readonly ISprite sprite;
        private int deathTimer = 0;
        private int deathTimerMax;

        public DeadWallMasterState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.Bounds = new Rectangle(this.Enemy.Physics.Bounds.Location, Point.Zero);
            deathTimerMax = GameData.Instance.EnemySpeedData.DeathTimerMax;
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
        }

        public override void Update()
        {
            this.deathTimer++;
            this.sprite.Update();
            if (deathTimer >= deathTimerMax)
            {
                this.Enemy.Expired = true;
                LoZGame.Instance.Drops.AttemptDrop(this.Enemy.Physics.Location);
            }
        }
    }
}
