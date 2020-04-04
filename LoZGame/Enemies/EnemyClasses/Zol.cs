namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Zol : EnemyEssentials, IEnemy
    {
        public bool ShouldMove { get; set; }

        private EnemyDamageData enemyDamageData;
        private EnemySpeedData enemySpeedData;

        public Zol(Vector2 location)
        {
            this.enemyDamageData = new EnemyDamageData();
            this.enemySpeedData = new EnemySpeedData();
            this.Health = new HealthManager(8);
            this.Physics = new Physics(location);
            this.CurrentState = new LeftMovingZolState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.ShouldMove = true;
            this.Expired = false;
            this.Damage = enemyDamageData.ZolDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = enemySpeedData.ZolSpeed;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }

        public override void Update()
        {
            this.HandleDamage();
            this.CurrentState.Update();
            this.Physics.SetDepth();
        }
    }
}