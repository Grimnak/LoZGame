namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class MagicBoomerangEnemy : IProjectile
    {
        private static readonly int LinkSize = 32;
        private static readonly int MaxDistance = 200;
        private static readonly int MaxSpeed = 5;
        private static readonly float Accel = 0.5f;
        private static readonly int XBound = 800;
        private static readonly int YBound = 480;

        private readonly Goriya Enemy;
        private readonly string direction;

        private readonly int scale = ProjectileSpriteFactory.Instance.Scale;
        private ProjectileCollisionHandler collisionHandler;
        private int projectileWidth;
        private int projectileHeight;
        private bool expired;
        private bool returning;
        private bool isReturned;
        private int distTraveled;
        private float currentSpeed;
        private Vector2 playerLoc;
        private ISprite sprite;
        private int damage;

        public int Damage { get { return damage; } set { damage = value; } }

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public MagicBoomerangEnemy(Goriya enemy)
        {
            this.projectileWidth = ProjectileSpriteFactory.Instance.StandardWidth * this.scale;
            this.projectileHeight = ProjectileSpriteFactory.Instance.BoomerangHeight * this.scale;
            this.collisionHandler = new ProjectileCollisionHandler(this);
            this.expired = false;
            Vector2 loc = enemy.Physics.Location;
            this.direction = enemy.Direction;
            this.isReturned = false;
            this.returning = false;
            this.Enemy = enemy;
            this.distTraveled = 0;
            this.damage = 1;

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

            this.playerLoc = enemy.Physics.Location;
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
            if (otherCollider is IEnemy)
            {
                this.returning = this.collisionHandler.OnCollisionResponse((IEnemy)otherCollider, collisionSide);
            }
            else if (otherCollider is IBlock)
            {
                this.returning = this.collisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
            else if (otherCollider is IPlayer)
            {
                this.returning = this.collisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IItem)
            {
                this.returning = this.collisionHandler.OnCollisionResponse((IItem)otherCollider, collisionSide);
            }
            else if (otherCollider is IDoor)
            {
                this.returning = this.collisionHandler.OnCollisionResponse((IDoor)otherCollider, collisionSide);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            this.returning = collisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

        private void ReturnHome()
        {
            this.playerLoc = this.Enemy.Physics.Location;
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

        public bool IsExpired { get { return this.expired; } set { this.expired = value; } }

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
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, ProjectileSpriteFactory.Instance.StandardWidth, ProjectileSpriteFactory.Instance.BoomerangHeight);
            this.CheckBounds();
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, Color.White);
        }
    }
}