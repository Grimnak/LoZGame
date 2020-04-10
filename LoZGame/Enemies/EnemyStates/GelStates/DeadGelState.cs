namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadGelState : GelEssentials, IEnemyState
    {
        private int deathTimer = 0;
        private int deathTimerMax;

        public DeadGelState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.Bounds = new Rectangle(this.Enemy.Physics.Bounds.Location, Point.Zero);
            this.Sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            deathTimerMax = GameData.Instance.EnemySpeedData.DeathTimerMax;
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