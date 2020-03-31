namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class WoodenSwordProjectile : ProjectileEssentials, IProjectile
    {
        private static readonly int LinkSize = LinkSpriteFactory.LinkHeight;
        private const int DrawOffset = 4;
        private SpriteEffects effect;
        private const int TotalLife = 15;
        private const int Extended = 10;
        private const int Retracting = 5;
        private ProjectileCollisionHandler collisionHandler;

        private int lifeTime;
        private Vector2 BoundsOffset;
        private readonly string direction;
        private readonly float rotation;
        private bool expired;
        private Physics source;
        private ISprite sprite;
        private int projectileWidth;
        private int projectileHeight;
        private int damage;

        public int StunDuration { get { return 0; } set {/*do nothing*/} }

        public bool Returning { get { return false; } set {/*do nothing*/} }

        public int Damage { get { return damage; } set { damage = value; } }

        public Physics Physics { get; set; }

        public EntityData Data { get; set; }

        private static readonly int FrameDelay = 5;
        private const int Speed = 0;

        public WoodenSwordProjectile(IPlayer source, string direction)
        {
            this.projectileWidth = LinkSpriteFactory.LinkWidth;
            this.projectileHeight = LinkSpriteFactory.LinkHeight;
            int locationOffset = (projectileWidth * 3) / 4;
            this.source = source.Physics;
            Vector2 sourceCenter = this.source.Bounds.Center.ToVector2();
            this.Data = new EntityData();
            this.collisionHandler = new ProjectileCollisionHandler(this);
            this.lifeTime = 0;
            this.InitializeDirection(this, source.Physics.Bounds, new Vector2(projectileWidth, projectileHeight), direction);
            this.Physics.MovementVelocity *= Speed;
            this.Physics.Location *= locationOffset;
            this.Physics.Location = new Vector2(sourceCenter.X + this.Physics.Location.X, sourceCenter.Y + this.Physics.Location.Y);
            this.Physics.Bounds = new Rectangle(this.Physics.Location.ToPoint() - this.Physics.BoundsOffset.ToPoint(), (this.Physics.BoundsOffset * 2).ToPoint());
            this.Physics.BoundsOffset *= 2;
            this.Physics.SetLocation();
            this.damage = 2;
            this.expired = false;
            if (source.CurrentColor.Equals("Red"))
            {
            }
            else if (source.CurrentColor.Equals("Blue"))
            {
            }
            else
            {
                this.sprite = ProjectileSpriteFactory.Instance.GreenWoodSword();
            }
        }

        public bool IsExpired { get { return this.expired; } set { this.expired = value; } }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public void Update()
        {
            lifeTime++;
            this.Physics.MovementVelocity = new Vector2(this.source.MovementVelocity.X, this.source.MovementVelocity.Y);
            if (this.lifeTime == Retracting || this.lifeTime == Extended)
            {
                this.sprite.NextFrame();
            }
            if (this.lifeTime >= TotalLife)
            {
                this.expired = true;
            }
            this.Physics.Move();
            this.Physics.SetDepth();
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint, this.Data.Rotation, this.Data.SpriteEffect, this.Physics.Depth);
        }
    }
}