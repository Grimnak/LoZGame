namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class MagicBoomerangProjectile : ProjectileEssentials, IProjectile
    {
        private static readonly int MaxDistance = 225;
        private static readonly int Speed = 7;
        private static readonly float Accel = 0.5f;
        private static readonly int StunLength = LoZGame.Instance.UpdateSpeed * 2;

        private ProjectileCollisionHandler collisionHandler;
        private readonly Physics source;
        private readonly string direction;
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

        public int StunDuration { get { return StunLength; } set {/*do nothing*/} }

        public bool Returning { get { return returning; } set { returning = value; } }

        public int Damage { get { return damage; } set { damage = value; } }

        public Physics Physics { get; set; }

        public EntityData Data { get; set; }

        public MagicBoomerangProjectile(Physics source, string direction)
        {
            this.projectileWidth = ProjectileSpriteFactory.Instance.StandardWidth * scale;
            this.projectileHeight = ProjectileSpriteFactory.Instance.BoomerangHeight * scale;
            this.collisionHandler = new ProjectileCollisionHandler(this);
            this.Data = new EntityData();
            this.expired = false;
            Vector2 loc = new Vector2(source.Bounds.X + (source.Bounds.Width / 2), source.Bounds.Y + (source.Bounds.Height / 2));
            this.InitializeDirection(this, source.Bounds, new Vector2(projectileWidth, projectileHeight), direction);
            this.Physics.MovementVelocity *= Speed;
            this.isReturned = false;
            this.returning = false;
            this.source = source;
            this.distTraveled = 0;
            this.damage = 0;
            this.sprite = ProjectileSpriteFactory.Instance.MagicBoomerang();
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
                float diffX = this.sourceLoc.X  - (this.Physics.Bounds.X + (this.Physics.Bounds.Width / 2));
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
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint, this.Physics.Depth);
        }
    }
}