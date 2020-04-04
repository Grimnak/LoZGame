namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class SpikeCross : EnemyEssentials, IEnemy
    {
        public bool Attacking { get; set; }

        public bool Retreating { get; set; }

        public Vector2 InitialPos { get; set; }

        private EnemyDamageData enemyDamageData;
        private EnemySpeedData enemySpeedData;

        public SpikeCross(Vector2 location)
        {
            this.enemyDamageData = new EnemyDamageData();
            this.enemySpeedData = new EnemySpeedData();
            this.Health = new HealthManager(1);
            this.Physics = new Physics(new Vector2(location.X, location.Y));
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.CurrentState = new IdleSpikeCrossState(this);
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Attacking = false;
            Retreating = false;
            InitialPos = this.Physics.Location;
            this.Expired = false;
            this.Damage = enemyDamageData.SpikeCrossDamage;
            this.DamageTimer = 0;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        public override void Update()
        {
            this.CurrentState.Update();
            this.Physics.Move();
        }
    }
}