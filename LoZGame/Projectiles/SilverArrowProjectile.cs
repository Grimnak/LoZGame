namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SilverArrowProjectile : ProjectileEssentials, IProjectile
    {
        private static readonly int Speed = 10;
        private static readonly Rectangle sourceSize = LoZGame.Instance.Link.Physics.Bounds;
        private static readonly int scale = ProjectileSpriteFactory.Instance.Scale;
        private Vector2 BoundsOffset;
        private ProjectileCollisionHandler collisionHandler;
        private readonly string direction;
        private readonly float rotation;
        private bool expired;
        private int projectileWidth;
        private int projectileHeight;
        private ISprite sprite;
        private int damage;

        public int StunDuration { get { return 0; } set {/*do nothing*/} }

        public bool Returning { get { return false; } set {/*do nothing*/} }

        public int Damage { get { return damage; } set { damage = value; } }

        public Physics Physics { get; set; }

        public EntityData Data { get; set; }

        public SilverArrowProjectile(Physics source, string direction)
        {
            this.projectileWidth = ProjectileSpriteFactory.Instance.ArrowWidth;
            this.projectileHeight = ProjectileSpriteFactory.Instance.ArrowHeight;
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
            this.damage = 2;
            this.expired = false;
            this.sprite = ProjectileSpriteFactory.Instance.Arrow();
        }

        public bool IsExpired { get { return this.expired; } set { this.expired = value; } }

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

        public void Update()
        {
            this.Physics.Move();
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint, this.Data.Rotation, this.Data.SpriteEffect, this.Physics.Depth);
        }
    }
}