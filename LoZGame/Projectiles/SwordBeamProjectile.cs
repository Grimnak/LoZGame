namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SwordBeamProjectile : IProjectile
    {
        private readonly int LinkSize = LinkSpriteFactory.LinkHeight;
        private const int DrawOffset = 4;
        private const int Delay = 10;

        private ProjectileCollisionHandler collisionHandler;

        private int lifeTime;
        private readonly int scale = ProjectileSpriteFactory.Instance.Scale;
        private readonly string direction;
        private readonly float rotation;
        private bool expired;
        private Vector2 tip;
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

        public Rectangle Bounds { get; set; }

        private static readonly int FrameDelay = 4;
        private const int Speed = 5;

        public SwordBeamProjectile(IPlayer player)
        {
            this.projectileWidth = ProjectileSpriteFactory.Instance.SwordBeamWidth * scale;
            this.projectileHeight = ProjectileSpriteFactory.Instance.SwordBeamHeight * scale;
            this.collisionHandler = new ProjectileCollisionHandler(this);
            this.lifeTime = 0;
            this.direction = player.CurrentDirection;
            Vector2 loc = new Vector2(player.Physics.Location.X, player.Physics.Location.Y);

            if (this.direction.Equals("Up"))
            {
                this.Physics = new Physics(new Vector2(loc.X + ((LinkSize - projectileWidth) / 2), loc.Y - LinkSize), new Vector2(0, -1 * Speed), new Vector2(0, 0));
                this.rotation = 0;
                this.effect = SpriteEffects.FlipVertically;
                this.Physics.Location = new Vector2(this.Physics.Location.X - DrawOffset, this.Physics.Location.Y);
                this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
                this.tip = new Vector2(projectileWidth, 0);
            }
            else if (this.direction.Equals("Left"))
            {
                this.Physics = new Physics(new Vector2(loc.X, loc.Y + ((LinkSize - projectileWidth) / 2)), new Vector2(-1 * Speed, 0), new Vector2(0, 0));
                this.rotation = MathHelper.PiOver2;
                this.effect = SpriteEffects.None;
                this.Physics.Location = new Vector2(this.Physics.Location.X, this.Physics.Location.Y + DrawOffset);
                this.Bounds = new Rectangle((int)this.Physics.Location.X - this.projectileHeight, (int)this.Physics.Location.Y, projectileHeight, projectileWidth);
                this.tip = new Vector2(-1 * projectileWidth, projectileHeight / 2);
            }
            else if (this.direction.Equals("Right"))
            {
                this.Physics = new Physics(new Vector2(loc.X + (LinkSize * 2), loc.Y + ((LinkSize - projectileWidth) / 2)), new Vector2(Speed, 0), new Vector2(0, 0));
                this.rotation = MathHelper.PiOver2;
                this.effect = SpriteEffects.FlipVertically;
                this.Physics.Location = new Vector2(this.Physics.Location.X, this.Physics.Location.Y + DrawOffset);
                this.Bounds = new Rectangle((int)this.Physics.Location.X - this.projectileHeight, (int)this.Physics.Location.Y, projectileHeight, projectileWidth);
                this.tip = new Vector2(projectileWidth, projectileHeight / 2);
            }
            else
            {
                this.Physics = new Physics(new Vector2(loc.X + ((LinkSize - projectileWidth) / 2), loc.Y + LinkSize), new Vector2(0, Speed), new Vector2(0, 0));
                this.rotation = 0;
                this.effect = SpriteEffects.None;
                this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
                this.tip = new Vector2(projectileWidth, projectileHeight);
            }
            this.damage = 10;
            this.expired = false;
            this.sprite = ProjectileSpriteFactory.Instance.SwordBeam(this.rotation, this.effect);
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
            int explosionType = LoZGame.Instance.Entities.ExplosionManager.SwordExplosion;
            Vector2 explosionLocation = new Vector2(this.Physics.Location.X + this.tip.X, this.Physics.Location.Y + this.tip.Y);
            LoZGame.Instance.Entities.ExplosionManager.AddExplosion(explosionType, explosionLocation);
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
                this.Bounds = new Rectangle((int)this.Bounds.X + (int)this.Physics.Velocity.X, (int)this.Bounds.Y + (int)this.Physics.Velocity.Y, this.Bounds.Width, this.Bounds.Height);
            }
        }

        public void Draw()
        {
            if (this.lifeTime > Delay)
            {
                this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint);
            }
        }
    }
}