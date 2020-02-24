namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SilverArrowProjectile : IProjectile
    {
        private static readonly int TravelRate = 10;
        private static readonly int LinkSize = 32;
        private static readonly int Width = 5;
        private static readonly int Height = 16;

        private readonly Texture2D texture;      // the texture to pull frames from
        private Rectangle frame;
        private Vector2 origin;
        private int lifeTime;
        private readonly int scale;
        private readonly string direction;
        private readonly float rotation;
        private readonly int dX;
        private readonly int dY;
        private readonly int instance;
        private bool expired;
        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        public Vector2 Location { get; set; }

        public SilverArrowProjectile(Texture2D texture, Vector2 loc, string direction, int scale, int instance)
        {
            this.origin = new Vector2(Width * scale / 2, Height * scale / 2);
            this.texture = texture;
            this.frame = new Rectangle(154, 16, Width, Height);
            this.lifeTime = 100;
            this.scale = scale;
            this.direction = direction;
            this.hostile = false;
            this.instance = instance;
            this.expired = false;
            if (this.direction.Equals("Up"))
            {
                this.Location = new Vector2(loc.X - ((Width * scale) - LinkSize), loc.Y);
                this.rotation = 0;
                this.dX = 0;
                this.dY = -1;
            }
            else if (this.direction.Equals("Left"))
            {
                this.Location = new Vector2(loc.X, loc.Y - (((Width * scale) - LinkSize) / 2));
                this.rotation = -1 * MathHelper.PiOver2;
                this.dX = -1;
                this.dY = 0;
            }
            else if (this.direction.Equals("Right"))
            {
                this.Location = new Vector2(loc.X + LinkSize, loc.Y - ((Width * scale) - LinkSize));
                this.rotation = MathHelper.PiOver2;
                this.dX = 1;
                this.dY = 0;
            }
            else
            {
                this.Location = new Vector2(loc.X - (((Width * scale) - LinkSize) / 2), loc.Y + LinkSize);
                this.rotation = MathHelper.Pi;
                this.dX = 0;
                this.dY = 1;
            }
        }

        public bool IsExpired => this.expired;

        public int Instance => this.instance;

        public void Update()
        {
            this.lifeTime--;
            if (this.lifeTime <= 0)
            {
                this.expired = true;
            }

            this.Location = new Vector2(this.Location.X + (this.dX * TravelRate), this.Location.Y + (this.dY * TravelRate));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.Location, this.frame, Color.White, this.rotation, this.origin, this.scale, SpriteEffects.None, 0f);
        }
    }
}