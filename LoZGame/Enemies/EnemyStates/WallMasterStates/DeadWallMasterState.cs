namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadWallMasterState : WallMasterEssentials, IEnemyState
    {
        private int deathTimer = 0;
        private int deathTimerMax;

        public DeadWallMasterState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.Bounds = new Rectangle(this.Enemy.Physics.Bounds.Location, Point.Zero);
            deathTimerMax = GameData.Instance.EnemyMiscConstants.DeathTimerMaximum;
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
        }

        public override void Update()
        {
            this.deathTimer++;
            this.Sprite.Update();
            if (deathTimer >= deathTimerMax)
            {
                LoZGame.Instance.Drops.AttemptDrop(this.Enemy.Physics.Location);
                this.Enemy.Expired = true;
            }
        }
    }
}
