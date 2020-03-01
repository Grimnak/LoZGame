namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SwordBeamProjectile : IProjectile
    {
        private const int LinkSize = 30;
        private const int Offset = 4;
        private const int Delay = 10;

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
        private Vector2 tip;
        private Vector2 origin;
        private Vector2 Size;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        private readonly ExplosionManager explosion;

        private static readonly int FrameDelay = 4;
        private const int Speed = 5;
        private static readonly int MaxLifeTime = 40;
        private static readonly int XBound = 800;
        private static readonly int YBound = 480;

        public SwordBeamProjectile(Texture2D texture, SpriteSheetData data, IPlayer player, int scale, int instance, ExplosionManager explosion)
        {
            this.Texture = texture;
            this.Data = data;
            this.scale = scale;
            this.Size = new Vector2(this.Data.Width * this.scale, this.Data.Height * this.scale);
            this.origin = new Vector2(this.Data.Width / 2, this.Data.Height / 2);
            this.frameOne = new Rectangle(0, 0, this.Data.Width, this.Data.Height);
            this.frameTwo = new Rectangle(0, this.Data.Height, this.Data.Width, this.Data.Height);
            this.frameThree = new Rectangle(0, this.Data.Height * 2, this.Data.Width, this.Data.Height);
            this.frameFour = new Rectangle(0, this.Data.Height * 3, this.Data.Width, this.Data.Height);
            this.explosion = explosion;
            this.currentFrame = this.frameOne;
            this.lifeTime = MaxLifeTime;
            this.direction = player.CurrentDirection;
            Vector2 loc = player.Physics.Location;
            this.hostile = false;

            if (this.direction.Equals("Up"))
            {
                this.Physics = new Physics(new Vector2(loc.X + (LinkSize - (this.Data.Width * scale / 2)), loc.Y), new Vector2(0, -1 * Speed), new Vector2(0, 0));
                this.rotation = MathHelper.Pi;
                this.tip = new Vector2(this.Size.X - Offset, 0);
            }
            else if (this.direction.Equals("Left"))
            {
                this.Physics = new Physics(new Vector2(loc.X, loc.Y + (LinkSize - (this.Data.Width * scale / 2))), new Vector2(-1 * Speed, 0), new Vector2(0, 0));
                this.rotation = 1 * MathHelper.PiOver2;
                this.tip = new Vector2(-1 * Offset, this.Size.X / 2);
            }
            else if (this.direction.Equals("Right"))
            {
                this.Physics = new Physics(new Vector2(loc.X + LinkSize, loc.Y + (LinkSize - (this.Data.Width * scale / 2))), new Vector2(Speed, 0), new Vector2(0, 0));
                this.rotation = -1 * MathHelper.PiOver2;
                this.tip = new Vector2(this.Size.Y - Offset, this.Size.X / 2);
            }
            else
            {
                this.Physics = new Physics(new Vector2(loc.X + (LinkSize - (this.Data.Width * scale / 2)), loc.Y + LinkSize), new Vector2(0, Speed), new Vector2(0, 0));
                this.rotation = 0;
                this.tip = new Vector2((this.Size.X / 2) - Offset, this.Size.Y);
            }
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.layer = this.Physics.Location.Y + this.Size.Y;
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
            if (this.Physics.Location.X >= XBound - this.tip.X || this.Physics.Location.X <= 0 || this.Physics.Location.Y >= YBound - this.tip.Y || this.Physics.Location.Y <= 0)
            {
                this.lifeTime = 0;
            }
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IEnemy)
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
                    this.explosion.AddExplosion(this.explosion.SwordExplosion, new Vector2(this.Physics.Location.X + this.tip.X, this.Physics.Location.Y + this.tip.Y));
                    this.expired = true;
                }

                this.Physics.Move();
                this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
                this.layer = this.Physics.Location.Y + this.Size.Y;
                this.CheckBounds();
            }
        }

        public void Draw()
        {
            if (this.lifeTime < MaxLifeTime - Delay)
            {
                LoZGame.Instance.SpriteBatch.Draw(this.Texture, this.Physics.Location, this.currentFrame, Color.White, this.rotation, this.origin, this.scale, SpriteEffects.None, this.layer);
            }
        }
    }
}