namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SwordBeamExplosion : IProjectile
    {
        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteSheetData Data;
        private Rectangle frameOne;
        private Rectangle frameTwo;
        private Rectangle frameThree;
        private Rectangle frameFour;
        private Rectangle currentFrame;
        private int lifeTime;
        private readonly int scale;
        private readonly string direction;
        private readonly float rotation;
        private readonly int instance;
        private bool expired;
        private float layer;
        private readonly SpriteEffects effect;
        private Vector2 origin;
        private Vector2 Size;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        private static readonly int FrameDelay = 4;
        private static readonly float Speed = 2.5F;
        private static readonly int MaxLifeTime = 60;

        public SwordBeamExplosion(Texture2D texture, SpriteSheetData data, Vector2 location, string direction, int scale, int instance)
        {
            this.Data = data;
            this.Size = new Vector2(this.Data.Width * scale, this.Data.Height * scale);
            this.Texture = texture;
            this.frameOne = new Rectangle(0, 0, this.Data.Width, this.Data.Height);
            this.frameTwo = new Rectangle(0, 12, this.Data.Width, this.Data.Height);
            this.frameThree = new Rectangle(0, 24, this.Data.Width, this.Data.Height);
            this.frameFour = new Rectangle(0, 36, this.Data.Width, this.Data.Height);
            this.currentFrame = this.frameOne;
            this.lifeTime = MaxLifeTime;
            this.scale = scale;
            this.direction = direction;
            this.Physics = new Physics(new Vector2(location.X - this.Size.X, location.Y - this.Size.Y), new Vector2(0, 0), new Vector2(0, 0));
            if (this.direction.Equals("NorthEast"))
            {
                this.Physics.Velocity = new Vector2(Speed, -1 * Speed);
                this.effect = SpriteEffects.FlipHorizontally;
                this.rotation = 0;
            }
            else if (this.direction.Equals("NorthWest"))
            {
                this.Physics.Velocity = new Vector2(-1 * Speed, -1 * Speed);
                this.effect = SpriteEffects.None;
                this.rotation = 0;
            }
            else if (this.direction.Equals("SouthEast"))
            {
                this.Physics.Velocity = new Vector2(Speed, Speed);
                this.Physics.Location = new Vector2(this.Physics.Location.X + this.Size.X, this.Physics.Location.Y + this.Size.Y);
                this.effect = SpriteEffects.None;
                this.rotation = MathHelper.Pi;
            }
            else
            {
                this.rotation = 0;
                this.Physics.Velocity = new Vector2(-1 * Speed, Speed);
                this.effect = SpriteEffects.FlipVertically;
            }

            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.layer = 1 / (this.Physics.Location.Y + this.Size.Y);
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

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            // do nothing
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
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.layer = 1 / (this.Physics.Location.Y + this.Size.Y);
            this.Physics.Move();
        }

        public void Draw()
        {
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, this.Physics.Location, this.currentFrame, Color.White, this.rotation, this.origin, this.scale, this.effect, this.layer);
        }
    }
}