namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Dodongo : EnemyEssentials, IEnemy
    {
        private EnemyDamageData enemyDamageData;
        private EnemySpeedData enemySpeedData;

        public Dodongo(Vector2 location)
        {
            this.enemyDamageData = new EnemyDamageData();
            this.enemySpeedData = new EnemySpeedData();
            this.Health = new HealthManager(32);
            this.Physics = new Physics(location);
            this.Physics.Mass = 10;
            this.Physics.IsMoveable = false;
            this.CurrentState = new LeftMovingDodongoState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = enemyDamageData.DodongoDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = enemySpeedData.DodongoSpeed;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        public override void Update()
        {
            this.HandleDamage();
            this.CurrentState.Update();
            this.Physics.SetDepth();
        }
    }
}