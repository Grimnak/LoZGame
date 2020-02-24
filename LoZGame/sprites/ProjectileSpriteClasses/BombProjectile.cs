namespace LoZGame
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BombProjectile : IProjectile
    {
        private static readonly int LinkSize = 32;
        private static readonly int Width = 8;
        private static readonly int Height = 16;
        private static readonly int MaxLife = 120;

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

        public Vector2 Location { get; set; }

        public BombProjectile(Texture2D texture, Vector2 loc, string direction, int scale, int instance, ExplosionManager explosion)
        {
            this.texture = texture;
            this.frame = new Rectangle(136, 0, Width, Height);
            this.lifeTime = MaxLife;
            this.instance = instance;
            this.direction = direction;
            this.hostile = false;
            this.explosion = explosion;
            if (this.direction == "Up")
            {
                this.Location = new Vector2(loc.X - (((Width * scale) - LinkSize) / 2), loc.Y - LinkSize);
            }
            else if (this.direction == "Left")
            {
                this.Location = new Vector2(loc.X - LinkSize + (LinkSize - (Width * scale)), loc.Y - (((Height * scale) - LinkSize) / 2));
            }
            else if (this.direction == "Right")
            {
                this.Location = new Vector2(loc.X + LinkSize, loc.Y - (((Height * scale) - LinkSize) / 2));
            }
            else
            {
                this.Location = new Vector2(loc.X - (((Width * scale) - LinkSize) / 2), loc.Y + LinkSize);
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
                Vector2 expolsionLoc = new Vector2(this.Location.X - (Width / 2) - (Height * this.scale), this.Location.Y - (Height * this.scale));
                this.explosion.AddExplosion(this.explosion.Explosion, expolsionLoc);
                this.expired = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.Location, this.frame, Color.White, 0, new Vector2(0, 0), this.scale, SpriteEffects.None, 0f);
        }
    }
}