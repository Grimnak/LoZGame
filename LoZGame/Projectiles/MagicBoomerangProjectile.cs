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

        private readonly IPlayer player;
        private readonly string direction;
        private int projectileWidth;
        private int projectileHeight;
        private int scale = ProjectileSpriteFactory.Instance.Scale;
        private bool expired;
        private bool returning;
        private bool reachedMaxDistance;
        private bool isReturned;
        private int distTraveled;
        private float currentSpeed;
        private Vector2 playerLoc;
        ISprite sprite;

        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public MagicBoomerangProjectile(IPlayer player)
        {
            this.projectileWidth = ProjectileSpriteFactory.Instance.StandardWidth * scale;
            this.projectileHeight = ProjectileSpriteFactory.Instance.BoomerangHeight * scale;
            this.expired = false;
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
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
            this.sprite = ProjectileSpriteFactory.Instance.MagicBoomerang();
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

        public void Update()
        {
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
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
            this.CheckBounds();
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, Color.White);
        }
    }
}