namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Merchant : IEnemy
    {
        private Rectangle bounds;
        private int health;
        private int damage = 0;
        private bool expired;

        public bool Expired { get { return this.expired; } set { this.expired = value; } }

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        public Physics Physics { get; set; }

        public HealthManager Health { get; set; }

        public int Damage => damage;

        public IEnemyState CurrentState { get; set; }

        private readonly ISprite sprite;

        public Merchant(Vector2 location)
        {
            this.Health = new HealthManager(health);
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.sprite = EnemySpriteFactory.Instance.CreateMerchantSprite();
            this.bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.health = 5;
            this.expired = false;
        }

        public void TakeDamage(int damageAmount)
        {
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint);
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
        }
    }
}