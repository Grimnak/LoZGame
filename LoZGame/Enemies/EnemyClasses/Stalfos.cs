namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Stalfos : EnemyEssentials, IEnemy
    {
        public EnemyDamageData EnemyDamageData { get; set; }

        public EnemySpeedData EnemySpeedData { get; set; }
        public Stalfos(Vector2 location)
        {
            this.EnemyDamageData = new EnemyDamageData();
            this.EnemySpeedData = new EnemySpeedData();
            this.Health = new HealthManager(EnemyDamageData.StalfosHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = 3;
            this.CurrentState = new LeftMovingStalfosState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = EnemyDamageData.StalfosDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = EnemySpeedData.StalfosSpeed;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }
    }
}
