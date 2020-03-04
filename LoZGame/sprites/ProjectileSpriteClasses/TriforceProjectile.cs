namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class TriforceProjectile : IProjectile
    {
        private static readonly int LinkSize = 32;
        private static readonly int Width = 10;
        private static readonly int Height = 16;
        private static readonly int FrameChange = 10;

        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteSheetData Data;
        private Vector2 origin;
        private Vector2 Size;
        private float rotation;
        private float layer;
        private Rectangle currentFrame;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private int lifeTime;
        private readonly int scale;
        private readonly int instance;
        private bool expired;
        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public static int LifeTime => 200;

        public TriforceProjectile(Texture2D texture, SpriteSheetData data, Vector2 loc, int scale, int instance)
        {
            this.Texture = texture;
            this.Data = data;
            this.firstFrame = new Rectangle(0, 0, data.Width, data.Height);
            this.secondFrame = new Rectangle(0, data.Height, data.Width, data.Height);
            this.currentFrame = this.firstFrame;
            this.lifeTime = LifeTime;
            this.Physics = new Physics(new Vector2(loc.X + ((LinkSize - Width) / (2 * scale)), loc.Y - LinkSize), new Vector2(0, 0), new Vector2(0, 0)); this.origin = new Vector2(data.Width / 2, data.Height / 2);
            this.Size = new Vector2(this.Data.Width * scale, this.Data.Width * scale);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.layer = 1 - 1 / (this.Physics.Location.Y + this.Size.Y);
            this.rotation = 0;
            this.scale = scale;
            this.expired = false;
            this.instance = instance;
            this.hostile = false;
        }

        private void NextFrame()
        {
            if (this.currentFrame == this.firstFrame)
            {
                this.currentFrame = this.secondFrame;
            }
            else
            {
                this.currentFrame = this.firstFrame;
            }
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            // do nothing
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

            if (this.lifeTime % FrameChange == 0)
            {
                this.NextFrame();
            }
        }

        public void Draw()
        {
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, this.Physics.Location, this.currentFrame, Color.White, this.rotation, this.origin, this.scale, SpriteEffects.None, this.layer);
        }
    }
}