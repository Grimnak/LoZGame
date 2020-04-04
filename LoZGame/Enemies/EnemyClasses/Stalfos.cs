namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Stalfos : EnemyEssentials, IEnemy
    {
        private EnemyDamageData enemyDamageData;
        private EnemySpeedData enemySpeedData;

        public Stalfos(Vector2 location)
        {
            this.enemyDamageData = new EnemyDamageData();
            this.enemySpeedData = new EnemySpeedData();
            this.Health = new HealthManager(8);
            this.Physics = new Physics(location);
            this.Physics.Mass = 3;
            this.CurrentState = new LeftMovingStalfosState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = enemyDamageData.StalfosDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = enemySpeedData.StalfosSpeed;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }
    }
}
