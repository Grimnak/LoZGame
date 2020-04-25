namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Merchant : EnemyEssentials, IEnemy
    {
        private readonly ISprite sprite;

        public Merchant(Vector2 location)
        {
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.MerchantHealth);
            Physics = new Physics(location);
            sprite = EnemySpriteFactory.Instance.CreateMerchantSprite();
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.MerchantDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.MerchantSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            DropTable = GameData.Instance.EnemyDropTables.EmptyDropTable;
            IsKillable = false;
        }

        public override void TakeDamage(int damageAmount)
        {
        }

        public override void Update()
        {
            Physics.SetDepth();
            sprite.Update();
        }

        public override void Draw()
        {
            sprite.Draw(Physics.Location, LoZGame.Instance.DefaultTint, Physics.Depth);
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateMerchantSprite();
        }
    }
}