namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SwordBeamProjectile : ProjectileEssentials, IProjectile
    {
        private readonly int LinkSize = LinkSpriteFactory.LinkHeight;
        private const int DrawOffset = 4;
        private const int Delay = 10;

        private ProjectileCollisionHandler collisionHandler;

        private int lifeTime;
        private readonly string direction;
        private readonly float rotation;
        private bool expired;
        private Vector2 origin;
        private ISprite sprite;
        private SpriteEffects effect;
        private int projectileWidth;
        private int projectileHeight;
        private int damage;

        public int StunDuration { get { return 0; } set {/*do nothing*/} }

        public bool Returning { get { return false; } set {/*do nothing*/} }

        public int Damage { get { return damage; } set { damage = value; } }

        public Physics Physics { get; set; }

        public EntityData Data { get; set; }

        private static readonly int FrameDelay = 4;
        private const int Speed = 5;

        public SwordBeamProjectile(Physics source, string direction)
        {
            this.projectileWidth = ProjectileSpriteFactory.Instance.SwordBeamWidth;
            this.projectileHeight = ProjectileSpriteFactory.Instance.SwordBeamHeight;
            int locationOffset = (projectileWidth * 3) / 4;
            Vector2 sourceCenter = source.Bounds.Center.ToVector2();
            this.Data = new EntityData();
            this.collisionHandler = new ProjectileCollisionHandler(this);
            this.lifeTime = 0;
            this.InitializeDirection(this, source.Bounds, new Vector2(projectileWidth, projectileHeight), direction);
            this.Physics.MovementVelocity *= Speed;
            this.Physics.Location *= locationOffset;
            this.Physics.Location = new Vector2(sourceCenter.X + this.Physics.Location.X, sourceCenter.Y + this.Physics.Location.Y);
            this.Physics.Bounds = new Rectangle(this.Physics.Location.ToPoint() - this.Physics.BoundsOffset.ToPoint(), (this.Physics.BoundsOffset * 2).ToPoint());
            this.Physics.BoundsOffset *= 2;
            this.Physics.SetLocation();
            this.damage = 2;
            this.expired = false;
            this.sprite = ProjectileSpriteFactory.Instance.SwordBeam();
        }

        public bool IsExpired { get { return this.expired; } set { this.expired = value; } }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IEnemy)
            {
                this.collisionHandler.OnCollisionResponse((IEnemy)otherCollider, collisionSide);
            }

            if (this.expired)
            {
                this.CreateExplosion();
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            collisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
            this.CreateExplosion();
        }

        private void CreateExplosion()
        {
            int explosionType = LoZGame.Instance.GameObjects.Entities.ExplosionManager.SwordExplosion;
            Vector2 explosionLoc = Vector2.Zero;
            if (direction == "Up") { explosionLoc = new Vector2(this.Physics.Bounds.Left + (this.Physics.Bounds.Width / 2), this.Physics.Bounds.Top); }
            else if (direction == "Down") { explosionLoc = new Vector2(this.Physics.Bounds.Left + (this.Physics.Bounds.Width / 2), this.Physics.Bounds.Bottom); }
            else if (direction == "Left") { explosionLoc = new Vector2(this.Physics.Bounds.Left, this.Physics.Bounds.Top + (this.Physics.Bounds.Height / 2)); }
            else if (direction == "Right") { explosionLoc = new Vector2(this.Physics.Bounds.Right, this.Physics.Bounds.Top + (this.Physics.Bounds.Height / 2)); }
            LoZGame.Instance.GameObjects.Entities.ExplosionManager.AddExplosion(explosionType, explosionLoc);
        }

        public void Update()
        {
            lifeTime++;
            if (this.lifeTime > Delay)
            {
                if (this.lifeTime % FrameDelay == 0)
                {
                    this.sprite.Update();
                }
                if (this.expired)
                {
                    this.CreateExplosion();
                }
                this.Physics.Move();
            }
        }

        public void Draw()
        {
            if (this.lifeTime > Delay)
            {
                this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint, this.Data.Rotation, this.Data.SpriteEffect, this.Physics.Depth);
            }
        }
    }
}