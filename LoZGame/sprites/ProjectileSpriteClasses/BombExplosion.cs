namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BombExplosion : IProjectile
    {
        private static readonly int MaxLifeTime = 90;
        private static readonly int DissipateOne = 20;
        private static readonly int DissipateTwo = 5;

        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteSheetData Data;
        private Rectangle frameOne;
        private Rectangle frameTwo;
        private Rectangle frameThree;
        private Rectangle currentFrame;
        private Vector2 origin;
        private Vector2 Size;
        private int lifeTime;
        private float layer;
        private readonly int scale;
        private readonly float rotation;
        private readonly int instance;
        private bool expired;


        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        public BombExplosion(Texture2D texture, SpriteSheetData data, Vector2 location, int scale, int instance)
        {
            this.Texture = texture;
            this.Data = data;
            this.Size = new Vector2(this.Data.Width * scale, this.Data.Height * scale);
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.frameOne = new Rectangle(0, 0, this.Data.Width, this.Data.Height);
            this.frameTwo = new Rectangle(0, this.Data.Height, this.Data.Width, this.Data.Height);
            this.frameThree = new Rectangle(0, this.Data.Height * 2, this.Data.Width, this.Data.Height);
            this.currentFrame = this.frameOne;
            this.lifeTime = MaxLifeTime;
            this.scale = scale;
            this.hostile = true;
            this.instance = instance;
            this.expired = false;
            this.rotation = 0;
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.layer = this.Physics.Location.Y + this.Size.Y;
            this.origin = new Vector2(this.Data.Width / 2, this.Data.Height / 2);
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
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            // do nothing
        }

        public void Update()
        {
            this.lifeTime--;
            if (this.lifeTime == DissipateOne || this.lifeTime == DissipateTwo)
            {
                this.NextFrame();
            }

            if (this.lifeTime <= 0)
            {
                this.expired = true;
            }
        }

        public void Draw()
        {
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, this.Physics.Location, this.currentFrame, Color.White, this.rotation, this.origin, this.scale, SpriteEffects.None, this.layer);
        }
    }
}