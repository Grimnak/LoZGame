namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class OldMan : IEnemy
    {
        private EnemyCollisionHandler enemyCollisionHandler;
        private Rectangle bounds;

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        public Vector2 CurrentLocation;
        private readonly OldManSprite sprite;

        public OldMan()
        {
            this.CurrentLocation = new Vector2(650, 200);
            this.sprite = EnemySpriteFactory.Instance.CreateOldManSprite();
            this.Bounds = new Rectangle((int)this.CurrentLocation.X, (int)this.CurrentLocation.Y, 30, 30);
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
        }

        public void TakeDamage()
        {
        }

        public void Die()
        {
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.CurrentLocation, Color.White);
        }

        public void OnCollisionResponse(ICollider otherCollider)
        {
            if (otherCollider is IProjectile)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider);
            }
        }
    }
}