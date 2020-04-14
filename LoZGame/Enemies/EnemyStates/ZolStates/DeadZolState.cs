namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadZolState : ZolEssentials, IEnemyState
    {
        private readonly IEnemy enemy;
        private readonly ISprite sprite;
        private int deathTimer = 0;
        private int deathTimerMax;

        public DeadZolState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.Enemy.IsDead = true;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            this.Enemy.CurrentState = this;
            this.Enemy.Physics.Bounds = new Rectangle(this.Enemy.Physics.Bounds.Location, Point.Zero);
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
            deathTimerMax = GameData.Instance.EnemyMiscConstants.DeathTimerMaximum;
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

        public override void Draw()
        {
            this.sprite.Draw(this.Enemy.Physics.Location, LoZGame.Instance.DungeonTint, this.Enemy.Physics.Depth);
        }
    }
}