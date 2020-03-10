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
        private Vector2 enemyLoc;
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
            Vector2 loc = new Vector2(enemy.Physics.Location.X + (LinkSize / 2), enemy.Physics.Location.Y + (LinkSize / 2));
            this.direction = enemy.Direction;
            this.isReturned = false;
            this.returning = false;
            this.Enemy = enemy;
            this.distTraveled = 0;
            this.damage = 1;

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

            this.enemyLoc = enemy.Physics.Location;
            this.enemyLoc = new Vector2(this.enemyLoc.X + 16, this.enemyLoc.Y + 16);
            this.currentSpeed = MaxSpeed;
            this.Bounds = new Rectangle((int)this.Physics.Location.X - (projectileWidth / 2), (int)this.Physics.Location.Y - (projectileHeight / 2), projectileWidth, projectileHeight);
            this.sprite = ProjectileSpriteFactory.Instance.MagicBoomerang();
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.returning = this.collisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            this.returning = collisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

        private void ReturnHome()
        {
            this.enemyLoc = this.Enemy.Physics.Location;
            this.enemyLoc = new Vector2(this.enemyLoc.X + 16, this.enemyLoc.Y + 16);
            float diffX = this.enemyLoc.X - this.Physics.Location.X;
            float diffY = this.enemyLoc.Y - this.Physics.Location.Y;
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
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}