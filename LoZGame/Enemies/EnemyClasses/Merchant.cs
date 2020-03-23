namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Merchant : EnemyEssentials, IEnemy
    {
        private readonly ISprite sprite;

        public Merchant(Vector2 location)
        {
            this.Health = new HealthManager(1);
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.sprite = EnemySpriteFactory.Instance.CreateMerchantSprite();
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.Expired = false;
            this.Damage = 0;
            this.DamageTimer = 0;
            this.MoveSpeed = 0;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        public override void TakeDamage(int damageAmount)
        {
        }

        public override void Update()
        {
            this.sprite.Update();
        }

        public override void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}