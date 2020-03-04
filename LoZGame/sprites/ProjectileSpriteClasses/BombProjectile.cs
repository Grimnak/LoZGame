namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BombProjectile : IProjectile
    {
        
        private static readonly int MaxLife = 120;
        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteSheetData Data;
        private Rectangle frame;
        private int lifeTime;
        private readonly int scale;
        private readonly bool isStatic;
        private bool expired;
        private readonly int instance;
        private float rotation;
        private readonly string direction;
        private readonly bool hostile;
        private readonly ExplosionManager explosion; 
        private float layer;
        private Vector2 origin;
        private Vector2 Size;

        public bool IsHostile => this.hostile;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public BombProjectile(Texture2D texture, SpriteSheetData data, Vector2 loc, string direction, int scale, int instance, ExplosionManager explosion)
        {
            this.Texture = texture;
            this.Data = data;
            this.frame = new Rectangle(0, 0, this.Data.Width, this.Data.Height);
            this.Size = new Vector2(this.Data.Width * scale, this.Data.Height * scale);
            this.origin = new Vector2(this.Data.Width / 2, this.Data.Height / 2);
            this.lifeTime = MaxLife;
            this.instance = instance;
            this.direction = direction;
            this.hostile = false;
            this.explosion = explosion;
            this.rotation = 0;
            if (this.direction == "Up")
            {
                this.Physics = new Physics(new Vector2(loc.X - ((this.Size.X - LinkSpriteFactory.LinkHeight) / 2), loc.Y - LinkSpriteFactory.LinkHeight), new Vector2(0, 0), new Vector2(0, 0));
            }
            else if (this.direction == "Left")
            {
                this.Physics = new Physics(new Vector2(loc.X - LinkSpriteFactory.LinkHeight + (LinkSpriteFactory.LinkHeight - this.Size.X), loc.Y - ((this.Size.Y - LinkSpriteFactory.LinkHeight) / 2)), new Vector2(0, 0), new Vector2(0, 0));
            }
            else if (this.direction == "Right")
            {
                this.Physics = new Physics(new Vector2(loc.X + LinkSpriteFactory.LinkHeight, loc.Y - ((this.Size.Y - LinkSpriteFactory.LinkHeight) / 2)), new Vector2(0, 0), new Vector2(0, 0));
            }
            else
            {
                this.Physics = new Physics(new Vector2(loc.X - ((this.Size.X - LinkSpriteFactory.LinkHeight) / 2), loc.Y + LinkSpriteFactory.LinkHeight), new Vector2(0, 0), new Vector2(0, 0));
            }

            this.scale = scale;
            this.isStatic = false;
            this.expired = false;
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.layer = 1 - 1 / (this.Physics.Location.Y + this.Size.Y);
        }

        public bool IsExpired => this.expired;

        public int Instance => this.instance;

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.lifeTime++;
            }
        }

        public void Update()
        {
            if (!this.isStatic)
            {
                this.lifeTime--;
            }

            if (this.lifeTime <= 0)
            {
                Vector2 explosionRadius = ProjectileSpriteFactory.Instance.ExplosionCenter;
                Vector2 expolsionLoc = new Vector2(this.origin.X - (explosionRadius.X * scale), this.origin.Y - (explosionRadius.Y * scale));
                this.explosion.AddExplosion(this.explosion.Explosion, expolsionLoc);
                this.expired = true;
            }
        }

        public void Draw()
        {
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, this.Physics.Location, this.frame, Color.White, this.rotation, this.origin, this.scale, SpriteEffects.None, this.layer);
        }
    }
}