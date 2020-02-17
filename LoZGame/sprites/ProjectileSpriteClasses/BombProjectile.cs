namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class BombProjectile : IProjectile
    {
        private static readonly int linkSize = 32;
        private static readonly int width = 8;
        private static readonly int height = 16;
        private static readonly int maxLife = 120;

        private readonly Texture2D texture;      // the texture to pull frames from
        private Rectangle frame;
        private int lifeTime;
        private readonly int scale;
        private readonly bool isStatic;
        private bool expired;
        private readonly int instance;
        private readonly string direction;
        private readonly bool hostile;
        private readonly ExplosionManager explosion;

        public bool IsHostile => this.hostile;

        public Vector2 location { get; set; }

        public BombProjectile(Texture2D texture, Vector2 loc, String direction, int scale, int instance, ExplosionManager explosion)
        {
            this.texture = texture;
            this.frame = new Rectangle(136, 0, width, height);
            this.lifeTime = maxLife;
            this.instance = instance;
            this.direction = direction;
            this.hostile = false;
            this.explosion = explosion;
            if (this.direction == "Up")
            {
                this.location = new Vector2(loc.X - ((width * scale) - linkSize) / 2, loc.Y - linkSize);
            }
            else if (this.direction == "Left")
            {
                this.location = new Vector2(loc.X - linkSize + (linkSize - width * scale), loc.Y - ((height * scale) - linkSize) / 2);
            }
            else if (this.direction == "Right")
            {
                this.location = new Vector2(loc.X + linkSize, loc.Y - ((height * scale) - linkSize) / 2);
            }
            else
            {
                this.location = new Vector2(loc.X - ((width * scale) - linkSize) / 2, loc.Y + linkSize);
            }

            this.scale = scale;
            this.isStatic = false;
            this.expired = false;
        }

        public bool IsExpired => this.expired;

        public int Instance => this.instance;

        public void Update()
        {
            if (!this.isStatic)
            {
                this.lifeTime--;
            }

            if (this.lifeTime <= 0)
            {
                Vector2 expolsionLoc = new Vector2(this.location.X - width / 2 - height * this.scale, this.location.Y - height * this.scale);
                this.explosion.addExplosion(this.explosion.Explosion, expolsionLoc);
                this.expired = true;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.location, this.frame, Color.White, 0, new Vector2(0, 0), this.scale, SpriteEffects.None, 0f);
        }
    }
}
