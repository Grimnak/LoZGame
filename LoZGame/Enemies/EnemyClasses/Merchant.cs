namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Merchant : EnemyEssentials, IEnemy
    {
        private readonly ISprite sprite;

        public EnemyDamageData EnemyDamageData { get; set; }

        public EnemySpeedData EnemySpeedData { get; set; }

        public Merchant(Vector2 location)
        {
            this.EnemyDamageData = new EnemyDamageData();
            this.EnemySpeedData = new EnemySpeedData();
            this.Health = new HealthManager(EnemyDamageData.MerchantHealth);
            this.Physics = new Physics(location);
            this.sprite = EnemySpriteFactory.Instance.CreateMerchantSprite();
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.Expired = false;
            this.Damage = EnemyDamageData.MerchantDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = EnemySpeedData.MerchantSpeed;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        public override void TakeDamage(int damageAmount)
        {
        }

        public override void Update()
        {
            this.Physics.Depth = 1 - (1 / this.Physics.Bounds.Bottom);
            this.sprite.Update();
        }

        public override void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint, this.Physics.Depth);
        }
    }
}