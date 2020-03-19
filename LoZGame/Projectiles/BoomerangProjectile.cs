namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BoomerangProjectile : IProjectile
    {
        private static readonly int LinkSize = 32;
        private static readonly int MaxDistance = 200;
        private static readonly int MaxSpeed = 5;
        private static readonly float Accel = 0.5f;

        private static readonly int StunLength = LoZGame.Instance.UpdateSpeed * 2;

        private readonly IPlayer player;
        private readonly string direction;
        private ProjectileCollisionHandler collisionHandler;
        private readonly int scale = ProjectileSpriteFactory.Instance.Scale;
        private int projectileWidth;
        private int projectileHeight;
        private bool expired;
        private bool returning;
        private bool isReturned;
        private float rotation;
        private int distTraveled;
        private float currentSpeed;
        private float layer;
        private Vector2 playerLoc;
        ISprite sprite;
        private int damage;

        public int StunDuration { get { return StunLength; } set {/*do nothing*/} }

        public bool Returning { get { return returning; } set { returning = value; } }

        public int Damage { get { return damage; } set { damage = value; } }

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public BoomerangProjectile(IPlayer player)
        {
            this.projectileWidth = ProjectileSpriteFactory.Instance.StandardWidth * scale;
            this.projectileHeight = ProjectileSpriteFactory.Instance.BoomerangHeight * scale;
            this.collisionHandler = new ProjectileCollisionHandler(this);
            this.expired = false;
            Vector2 loc = new Vector2(player.Physics.Location.X + (LinkSize / 2), player.Physics.Location.Y + (LinkSize / 2));
            this.direction = player.CurrentDirection;
            this.isReturned = false;
            this.returning = false;
            this.player = player;
            this.distTraveled = 0;
            this.damage = 0;

            if (this.direction.Equals("Up"))
            {
                this.Physics = new Physics(new Vector2(loc.X, loc.Y - (LinkSize / 2)), new Vector2(0, -1 * MaxSpeed), new Vector2(0, 0));
            }
            else if (this.direction.Equals("Left"))
            {
                this.Physics = new Physics(new Vector2(loc.X - (LinkSize / 2), loc.Y), new Vector2(-1 * MaxSpeed, 0), new Vector2(0, 0));
            }
            else if (this.direction.Equals("Right"))
            {
                this.Physics = new Physics(new Vector2(loc.X + (LinkSize / 2), loc.Y), new Vector2(MaxSpeed, 0), new Vector2(0, 0));
            }
            else
            {
                this.Physics = new Physics(new Vector2(loc.X, loc.Y + (LinkSize / 2)), new Vector2(0, MaxSpeed), new Vector2(0, 0));
            }

            this.playerLoc = player.Physics.Location;
            this.playerLoc = new Vector2(this.playerLoc.X + 16, this.playerLoc.Y + 16);
            this.currentSpeed = MaxSpeed;
            this.Bounds = new Rectangle((int)this.Physics.Location.X - (projectileWidth / 2), (int)this.Physics.Location.Y - (projectileHeight / 2), projectileWidth, projectileHeight);
            this.sprite = ProjectileSpriteFactory.Instance.Boomerang();
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IEnemy)
            {
                this.collisionHandler.OnCollisionResponse((IEnemy)otherCollider, collisionSide);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            collisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
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
            this.Bounds = new Rectangle((int)this.Physics.Location.X - (projectileWidth / 2), (int)this.Physics.Location.Y - (projectileHeight / 2), projectileWidth, projectileHeight);
            this.sprite.Update();
        }

        public void Draw()
        {
            sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}