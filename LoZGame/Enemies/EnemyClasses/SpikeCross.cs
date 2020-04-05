namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class SpikeCross : EnemyEssentials, IEnemy
    {
        public bool Attacking { get; set; }

        public bool Retreating { get; set; }

        public Vector2 InitialPos { get; set; }

        public EnemyDamageData EnemyDamageData { get; set; }

        public EnemySpeedData EnemySpeedData { get; set; }

        public SpikeCross(Vector2 location)
        {
            this.EnemyDamageData = new EnemyDamageData();
            this.EnemySpeedData = new EnemySpeedData();
            this.Health = new HealthManager(EnemyDamageData.SpikeCrossHealth);
            this.Physics = new Physics(new Vector2(location.X, location.Y));
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.CurrentState = new IdleSpikeCrossState(this);
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Attacking = false;
            Retreating = false;
            InitialPos = this.Physics.Location;
            this.Expired = false;
            this.Damage = EnemyDamageData.SpikeCrossDamage;
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