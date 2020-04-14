namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Merchant : EnemyEssentials, IEnemy
    {
        private readonly ISprite sprite;

        public Merchant(Vector2 location)
        {
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.MerchantHealth);
            this.Physics = new Physics(location);
            this.sprite = EnemySpriteFactory.Instance.CreateMerchantSprite();
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.MerchantDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.MerchantSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
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
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DefaultTint, this.Physics.Depth);
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateMerchantSprite();
        }
    }
}