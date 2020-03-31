namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BoomerangProjectile : ProjectileEssentials, IProjectile
    {
        private static readonly int MaxDistance = 150;
        private static readonly int Speed = 5;
        private static readonly float Accel = 0.5f;

        private static readonly int StunLength = LoZGame.Instance.UpdateSpeed;

        private ProjectileCollisionHandler collisionHandler;
        private readonly Physics source;
        private int projectileWidth;
        private int projectileHeight;
        private int scale = ProjectileSpriteFactory.Instance.Scale;
        private bool expired;
        private bool returning;
        private bool isReturned;
        private int distTraveled;
        private Vector2 sourceLoc;
        ISprite sprite;
        private int damage;

        public int StunDuration { get { return StunLength; } }

        public bool Returning { get { return returning; } set { returning = value; } }

        public int Damage { get { return damage; } set { damage = value; } }

        public Physics Physics { get; set; }

        public EntityData Data { get; set; }

        public BoomerangProjectile(Physics source, string direction)
        {
            this.projectileWidth = ProjectileSpriteFactory.Instance.StandardWidth;
            this.projectileHeight = ProjectileSpriteFactory.Instance.BoomerangHeight;
            this.source = source;
            this.isReturned = false;
            this.returning = false;
            this.distTraveled = 0;
            this.damage = 0;
            int locationOffset = (projectileWidth * 3) / 4;
            Vector2 sourceCenter = source.Bounds.Center.ToVector2();
            this.Data = new EntityData();
            this.collisionHandler = new ProjectileCollisionHandler(this);
            this.InitializeDirection(this, source.Bounds, new Vector2(projectileWidth, projectileHeight), direction);
            this.Physics.MovementVelocity *= Speed;
            this.Physics.Location *= locationOffset;
            this.Physics.Location = new Vector2(sourceCenter.X + this.Physics.Location.X, sourceCenter.Y + this.Physics.Location.Y);
            this.Physics.Bounds = new Rectangle(this.Physics.Location.ToPoint() - this.Physics.BoundsOffset.ToPoint(), (this.Physics.BoundsOffset * 2).ToPoint());
            this.Physics.BoundsOffset *= 2;
            this.Physics.SetLocation();
            this.expired = false;
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
            if (this.Physics.Bounds.Intersects(this.source.Bounds))
            {
                this.isReturned = true;
            }
            else
            {
                this.sourceLoc = new Vector2(this.source.Bounds.X + (this.source.Bounds.Width / 2), this.source.Bounds.Y + (this.source.Bounds.Height / 2));
                float diffX = this.sourceLoc.X - (this.Physics.Bounds.X + (this.Physics.Bounds.Width / 2));
                float diffY = this.sourceLoc.Y - (this.Physics.Bounds.Y + (this.Physics.Bounds.Height / 2));
                float diffTotal = (float)Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2));
                this.Physics.MovementVelocity = new Vector2(diffX / diffTotal * Speed, diffY / diffTotal * Speed);
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
                this.distTraveled += Speed;
            }
            if (this.returning)
            {
                this.ReturnHome();
            }
            this.Physics.Move();
            this.sprite.Update();
            this.Data.Rotation += MathHelper.PiOver4 / 2;
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint, this.Data.Rotation, this.Data.SpriteEffect, this.Physics.Depth);
        }
    }
}