namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BombProjectile : IProjectile
    {
        private static readonly int LinkSize = LinkSpriteFactory.LinkHeight;
        private static readonly int MaxLife = 120;
        private int lifeTime;
        private readonly int scale;
        private bool expired;
        private readonly string direction;
        private int projectileWidth;
        private int projectileHeight;
        private ISprite sprite;
        private ProjectileCollisionHandler collisionHandler;
        private int damage;

        public int Damage { get { return damage; } set { damage = value; } }

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public BombProjectile(Vector2 loc, string direction)
        {
            this.scale = ProjectileSpriteFactory.Instance.Scale;
            this.projectileWidth = ProjectileSpriteFactory.Instance.StandardWidth * scale;
            this.projectileHeight = ProjectileSpriteFactory.Instance.StandardHeight * scale;
            this.lifeTime = MaxLife;
            this.direction = direction;
            this.damage = 0;
            if (this.direction == "Up")
            {
                this.Physics = new Physics(new Vector2(loc.X + ((LinkSize - this.projectileWidth) / 2), loc.Y - LinkSize), new Vector2(0, 0), new Vector2(0, 0));
            }
            else if (this.direction == "Left")
            {
                this.Physics = new Physics(new Vector2(loc.X - LinkSize + (LinkSize - projectileWidth), loc.Y - ((projectileHeight - LinkSize) / 2)), new Vector2(0, 0), new Vector2(0, 0));
            }
            else if (this.direction == "Right")
            {
                this.Physics = new Physics(new Vector2(loc.X + LinkSize, loc.Y - ((projectileHeight - LinkSize) / 2)), new Vector2(0, 0), new Vector2(0, 0));
            }
            else
            {
                this.Physics = new Physics(new Vector2(loc.X - ((projectileWidth - LinkSize) / 2), loc.Y + LinkSize), new Vector2(0, 0), new Vector2(0, 0));
            }
            this.collisionHandler = new ProjectileCollisionHandler(this);
            this.expired = false;
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
            this.sprite = ProjectileSpriteFactory.Instance.Bomb();
        }

        public bool IsExpired { get { return this.expired; } set { this.expired = value; } }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IEnemy)
            {
                this.collisionHandler.OnCollisionResponse((IEnemy)otherCollider, collisionSide);
            }
            else if (otherCollider is IPlayer)
            {
                this.collisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IItem)
            {
                this.collisionHandler.OnCollisionResponse((IItem)otherCollider, collisionSide);
            }
            else if (otherCollider is IDoor)
            {
                this.collisionHandler.OnCollisionResponse((IDoor)otherCollider, collisionSide);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            collisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

        public void Update()
        {
            lifeTime--;
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
            if (this.lifeTime <= 0)
            {
                this.expired = true;
                int explosiontype = (int)LoZGame.Instance.Entities.ExplosionManager.Explosion;
                Vector2 bombCenter = new Vector2(this.Physics.Location.X + (this.projectileWidth / 2), this.Physics.Location.Y + (this.projectileHeight / 2));
                this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
                LoZGame.Instance.Entities.ExplosionManager.AddExplosion(explosiontype, bombCenter);
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}