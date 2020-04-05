namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Zol : EnemyEssentials, IEnemy
    {
        public bool ShouldMove { get; set; }


        public EnemyDamageData EnemyDamageData { get; set; }

        public EnemySpeedData EnemySpeedData { get; set; }

        public Zol(Vector2 location)
        {
            this.EnemyDamageData = new EnemyDamageData();
            this.EnemySpeedData = new EnemySpeedData();
            this.Health = new HealthManager(EnemyDamageData.ZolHealth);
            this.Physics = new Physics(location);
            this.CurrentState = new LeftMovingZolState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.ShouldMove = true;
            this.Expired = false;
            this.Damage = EnemyDamageData.ZolDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = EnemySpeedData.ZolSpeed;
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