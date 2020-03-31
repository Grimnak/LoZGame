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
            this.projectileWidth = ProjectileSpriteFactory.Instance.ArrowWidth * scale;
            this.projectileHeight = ProjectileSpriteFactory.Instance.StandardHeight * scale;
            this.Data = new EntityData();
            this.InitializeDirection(this, source.Bounds, new Vector2(projectileWidth, projectileHeight), direction);
            this.Physics.MovementVelocity *= Speed;
            this.collisionHandler = new ProjectileCollisionHandler(this);
            this.expired = false;
            this.damage = 8;
            this.sprite = ProjectileSpriteFactory.Instance.SilverArrow();
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
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint, this.Physics.Depth);
        }
    }
}