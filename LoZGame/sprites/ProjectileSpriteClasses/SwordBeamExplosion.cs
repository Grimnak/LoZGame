namespace LoZGame
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SwordBeamExplosion : IProjectile
    {
        private static readonly int Width = 10;
        private static readonly int Height = 12;

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
        private readonly SpriteEffects effect;

        public Vector2 Location { get; set; }

        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        private static readonly int FrameDelay = 4;
        private static readonly float Speed = 2.5F;
        private static readonly int MaxLifeTime = 60;

        public SwordBeamExplosion(Texture2D texture, Vector2 location, string direction, int scale, int instance)
        {
            location = new Vector2(location.X - (Width * scale), location.Y - (Height * scale));
            this.texture = texture;
            this.frameOne = new Rectangle(0, 0, Width, Height);
            this.frameTwo = new Rectangle(0, 12, Width, Height);
            this.frameThree = new Rectangle(0, 24, Width, Height);
            this.frameFour = new Rectangle(0, 36, Width, Height);
            this.currentFrame = this.frameOne;
            this.lifeTime = MaxLifeTime;
            this.scale = scale;
            this.direction = direction;
            this.Location = new Vector2(location.X, location.Y);
            if (this.direction.Equals("NorthEast"))
            {
                this.effect = SpriteEffects.FlipHorizontally;
                this.rotation = 0;
                this.dX = 1;
                this.dY = -1;
            }
            else if (this.direction.Equals("NorthWest"))
            {
                this.effect = this.effect = SpriteEffects.None;
                this.rotation = 0;
                this.dX = -1;
                this.dY = -1;
            }
            else if (this.direction.Equals("SouthEast"))
            {
                this.Location = new Vector2(this.Location.X + (Width * scale), this.Location.Y + (Height * scale));
                this.effect = SpriteEffects.None;
                this.rotation = MathHelper.Pi;
                this.dX = 1;
                this.dY = 1;
            }
            else
            {
                this.rotation = 0;
                this.effect = SpriteEffects.FlipVertically;
                this.dX = -1;
                this.dY = 1;
            }

            this.instance = instance;
            this.hostile = false;
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

        public void Update()
        {
            this.lifeTime--;
            if (this.lifeTime % FrameDelay == 0)
            {
                this.NextFrame();
            }

            if (this.lifeTime <= 0)
            {
                this.expired = true;
            }

            this.Location = new Vector2(this.Location.X + (this.dX * Speed), this.Location.Y + (this.dY * Speed));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.Location, this.currentFrame, Color.White, this.rotation, new Vector2(0, 0), this.scale, this.effect, 0f);
        }
    }
}