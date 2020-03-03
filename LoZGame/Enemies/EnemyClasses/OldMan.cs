namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class OldMan : IEnemy
    {
        private EnemyCollisionHandler enemyCollisionHandler;
        private Rectangle bounds;
        private int health;
        private int damage = 0;

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        public Physics Physics { get; set; }

        public HealthManager Health { get; set; }

        public int Damage => damage;

        public IEnemyState CurrentState { get; set; }

        private readonly OldManSprite sprite;

        public OldMan(Vector2 location)
        {
            this.Health = new HealthManager(health);
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.sprite = EnemySpriteFactory.Instance.CreateOldManSprite();
            this.bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
            this.health = 5;
        }

        public void TakeDamage(int damageAmount)
        {
        }

        public void Die()
        {
        }

        public void Update()
        {
            this.sprite.Update();
            this.bounds.X = (int)this.Physics.Location.X;
            this.bounds.Y = (int)this.Physics.Location.Y;
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, Color.White);
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IBlock)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
            else if (otherCollider is IProjectile)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
        }
    }
}
