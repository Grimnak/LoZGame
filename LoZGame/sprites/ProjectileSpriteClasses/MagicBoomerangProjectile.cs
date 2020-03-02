namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class MagicBoomerangProjectile : IProjectile
    {
        private static readonly int LinkSize = 32;
        private static readonly int MaxDistance = 300;
        private static readonly int MaxSpeed = 5;
        private static readonly float Accel = 0.5f;
        private static readonly int XBound = 800;
        private static readonly int YBound = 480;

        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteSheetData Data;
        private Rectangle frame;
        private Vector2 origin;
        private Vector2 Size;
        private readonly IPlayer player;
        private readonly int scale;
        private readonly int dX;
        private readonly int dY;
        private readonly string direction;

        private readonly int instance;
        private bool expired;
        private bool returning;
        private bool reachedMaxDistance;
        private bool isReturned;
        private float rotation;
        private int distTraveled;
        private float currentSpeed;
        private float layer;
        private Vector2 playerLoc;

        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public MagicBoomerangProjectile(Texture2D texture, SpriteSheetData data, IPlayer player, int scale, int instance)
        {
            this.Texture = texture;
            this.Data = data;
            this.Size = new Vector2(this.Data.Width * scale, this.Data.Height * scale);
            this.frame = new Rectangle(0, 0, this.Data.Width, this.Data.Height);
            this.origin = new Vector2(this.Data.Width / 2, this.Data.Height / 2);
            this.scale = scale;
            this.instance = instance;
            this.expired = false;
            this.rotation = 0;
            Vector2 loc = player.Physics.Location;
            this.direction = player.CurrentDirection;
            this.isReturned = false;
            this.returning = false;
            this.player = player;
            this.distTraveled = 0;
            this.hostile = false;
            this.reachedMaxDistance = false;

            if (this.direction.Equals("Up"))
            {
                this.Physics = new Physics(new Vector2(loc.X + (LinkSize / 2), loc.Y), new Vector2(0, -1 * MaxSpeed), new Vector2(0, 0));
            }
            else if (this.direction.Equals("Left"))
            {
                this.Physics = new Physics(new Vector2(loc.X, loc.Y + (LinkSize / 2)), new Vector2(-1 * MaxSpeed, 0), new Vector2(0, 0));
            }
            else if (this.direction.Equals("Right"))
            {
                this.Physics = new Physics(new Vector2(loc.X + LinkSize, loc.Y + (LinkSize / 2)), new Vector2(MaxSpeed, 0), new Vector2(0, 0));
            }
            else
            {
                this.Physics = new Physics(new Vector2(loc.X + (LinkSize / 2), loc.Y + LinkSize), new Vector2(0, MaxSpeed), new Vector2(0, 0));
            }

            this.playerLoc = player.Physics.Location;
            this.playerLoc = new Vector2(this.playerLoc.X + 16, this.playerLoc.Y + 16);
            this.currentSpeed = MaxSpeed; 
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.layer = 1 / (this.Physics.Location.Y + this.Size.Y);
        }

        private void Rotate()
        {
            this.rotation += MathHelper.PiOver4 / 2;
        }

        private void CheckBounds()
        {
            if (this.Physics.Location.X >= XBound || this.Physics.Location.X <= 0 || this.Physics.Location.Y >= YBound || this.Physics.Location.Y <= 0)
            {
                this.returning = true;
            }
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IEnemy || otherCollider is IBlock)
            {
                this.returning = true;
            }
        }

        private void ReturnHome()
        {
            this.playerLoc = this.player.Physics.Location;
            this.playerLoc = new Vector2(this.playerLoc.X + 16, this.playerLoc.Y + 16);
            float diffX = this.playerLoc.X - this.Physics.Location.X;
            float diffY = this.playerLoc.Y - this.Physics.Location.Y;
            if (Math.Abs(diffX) <= 2 * MaxSpeed && Math.Abs(diffY) <= 2 * MaxSpeed)
            {
                this.isReturned = true;
            }
            else
            {
                this.currentSpeed = (float)Math.Sqrt(Math.Pow(this.Physics.Velocity.X, 2) + Math.Pow(this.Physics.Velocity.Y, 2));
                if (this.currentSpeed <= MaxSpeed)
                {
                    this.currentSpeed += Accel;
                }
                float diffTotal = (float)Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2));
                this.Physics.Velocity = new Vector2(diffX / diffTotal * currentSpeed, diffY / diffTotal * currentSpeed);
            }
        }


        public bool IsExpired => this.expired;

        public int Instance => this.instance;

        public void Update()
        {
            this.Rotate();
            if (this.isReturned)
            {
                this.expired = true;
            }
            if (this.distTraveled >= MaxDistance)
            {
                this.returning = true;
            }
            else
            {
                this.distTraveled += MaxSpeed;
            }
            if (this.returning)
            {
                this.ReturnHome();
            }
            this.Physics.Move();
            this.layer = 1 / (this.Physics.Location.Y + this.Size.Y);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.CheckBounds();
        }

        public void Draw()
        {
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, this.Physics.Location, this.frame, Color.White, this.rotation, this.origin, this.scale, SpriteEffects.None, this.layer);
        }
    }
}