namespace LoZGame
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SwordBeamProjectile : IProjectile
    {
        private static readonly int LinkSize = 32;
        private static readonly int Width = 15;
        private static readonly int Height = 16;
        private static readonly int Offset = 4;

        private readonly Texture2D texture;      // the texture to pull frames from
        private Rectangle frameOne;
        private Rectangle frameTwo;
        private Rectangle frameThree;
        private Rectangle frameFour;
        private Rectangle currentFrame;
        private readonly int dX;
        private readonly int dY;
        private int lifeTime;
        private readonly int scale;
        private readonly string direction;
        private readonly float rotation;
        private readonly int instance;
        private bool expired;
        private Vector2 tip;
        private Vector2 origin;
        private static readonly int Delay = 10;

        public Vector2 Location { get; set; }

        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        private readonly ExplosionManager explosion;

        private static readonly int FrameDelay = 4;
        private static readonly int Speed = 5;
        private static readonly int MaxLifeTime = 40;
        private static readonly int XBound = 800;
        private static readonly int YBound = 480;

        public SwordBeamProjectile(Texture2D texture, IPlayer player, int scale, int instance, ExplosionManager explosion)
        {
            this.origin = new Vector2(Width / 2, Height / 2);
            this.texture = texture;
            this.frameOne = new Rectangle(0, 0, Width, Height);
            this.frameTwo = new Rectangle(0, 16, Width, Height);
            this.frameThree = new Rectangle(0, 32, Width, Height);
            this.frameFour = new Rectangle(0, 48, Width, Height);
            this.explosion = explosion;
            this.currentFrame = this.frameOne;
            this.lifeTime = MaxLifeTime;
            this.scale = scale;
            this.direction = player.CurrentDirection;
            Vector2 loc = player.CurrentLocation;
            this.hostile = false;

            if (this.direction.Equals("Up"))
            {
                this.Location = new Vector2(loc.X + (LinkSize - (Width * scale / 2)), loc.Y);
                this.rotation = MathHelper.Pi;
                this.dX = 0;
                this.dY = -1;
                this.tip = new Vector2(Width - Offset, 0);
            }
            else if (this.direction.Equals("Left"))
            {
                this.Location = new Vector2(loc.X, loc.Y + (LinkSize - (Width * scale / 2)));
                this.rotation = 1 * MathHelper.PiOver2;
                this.dX = -1;
                this.dY = 0;
                this.tip = new Vector2(-1 * Offset, Width);
            }
            else if (this.direction.Equals("Right"))
            {
                this.Location = new Vector2(loc.X + LinkSize, loc.Y + (LinkSize - (Width * scale / 2)));
                this.rotation = -1 * MathHelper.PiOver2;
                this.dX = 1;
                this.dY = 0;
                this.tip = new Vector2((Height * scale) - Offset, Width);
            }
            else
            {
                this.Location = new Vector2(loc.X + (LinkSize - (Width * scale / 2)), loc.Y + LinkSize);
                this.rotation = 0;
                this.dX = 0;
                this.dY = 1;
                this.tip = new Vector2(Width - Offset, Height * scale);
            }

            this.instance = instance;
            this.expired = false;
        }

        public bool IsExpired => this.expired;

        public int Instance => this.instance;

        private void NextFrame()
        {
            if (this.currentFrame == this.frameOne)
            {
                this.currentFrame = this.frameTwo;
            }
            else if (this.currentFrame == this.frameTwo)
            {
                this.currentFrame = this.frameThree;
            }
            else if (this.currentFrame == this.frameThree)
            {
                this.currentFrame = this.frameFour;
            }
            else
            {
                this.currentFrame = this.frameOne;
            }
        }

        private void CheckBounds()
        {
            if (this.Location.X >= XBound - Height || this.Location.X <= 0 || this.Location.Y >= YBound - Height || this.Location.Y <= 0)
            {
                this.lifeTime = 0;
            }
        }

        public void Update()
        {
            this.lifeTime--;
            if (this.lifeTime < MaxLifeTime - Delay)
            {
                if (this.lifeTime % FrameDelay == 0)
                {
                    this.NextFrame();
                }

                if (this.lifeTime <= 0)
                {
                    this.explosion.AddExplosion(this.explosion.SwordExplosion, new Vector2(this.Location.X + this.tip.X, this.Location.Y + this.tip.Y));
                    this.expired = true;
                }

                this.Location = new Vector2(this.Location.X + (this.dX * Speed), this.Location.Y + (this.dY * Speed));
                this.CheckBounds();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.lifeTime < MaxLifeTime - Delay)
            {
                spriteBatch.Draw(this.texture, this.Location, this.currentFrame, Color.White, this.rotation, this.origin, this.scale, SpriteEffects.None, 0f);
            }
        }
    }
}