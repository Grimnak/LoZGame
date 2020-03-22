namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class WoodenSwordProjectile : IProjectile
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
        private IPlayer player;
        private ISprite sprite;
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

        public WoodenSwordProjectile(IPlayer player)
        {
            this.player = player;
            this.projectileWidth = ProjectileSpriteFactory.Instance.SwordWidth;
            this.projectileHeight = ProjectileSpriteFactory.Instance.SwordHeight;             
            this.collisionHandler = new ProjectileCollisionHandler(this);
            this.lifeTime = TotalLife;
            this.direction = player.CurrentDirection;
            Vector2 loc = new Vector2(player.Physics.Location.X, player.Physics.Location.Y);
            if (this.direction.Equals("Up"))
            {
                this.Physics = new Physics(new Vector2(loc.X + ((LinkSize - projectileWidth) / 2), loc.Y - ((3 * LinkSize) / 4)), Vector2.Zero, Vector2.Zero);
                this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
                this.rotation = 0.0f;
                this.effect = SpriteEffects.FlipVertically;
                this.Physics.Location = new Vector2(this.Physics.Location.X - DrawOffset, this.Physics.Location.Y);
            }
            else if (this.direction.Equals("Left"))
            {
                this.Physics = new Physics(new Vector2(loc.X + (LinkSize / 4), loc.Y + ((LinkSize - projectileWidth) / 2)), Vector2.Zero, Vector2.Zero);
                this.Bounds = new Rectangle((int)this.Physics.Location.X - projectileHeight, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
                this.rotation = MathHelper.PiOver2;
                this.effect = SpriteEffects.None;
                this.Physics.Location = new Vector2(this.Physics.Location.X, this.Physics.Location.Y + DrawOffset);
            }
            else if (this.direction.Equals("Right"))
            {
                this.Physics = new Physics(new Vector2(loc.X + (LinkSize * 2) - (LinkSize / 4), loc.Y + ((LinkSize - projectileWidth) / 2)), Vector2.Zero, Vector2.Zero);
                this.Bounds = new Rectangle((int)this.Physics.Location.X - projectileHeight, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
                this.rotation = MathHelper.PiOver2;
                this.effect = SpriteEffects.FlipVertically;
                this.Physics.Location = new Vector2(this.Physics.Location.X, this.Physics.Location.Y + DrawOffset);
            }
            else
            {
                this.Physics = new Physics(new Vector2(loc.X + ((LinkSize - projectileWidth) / 2), loc.Y + ((3 * LinkSize) / 4)), Vector2.Zero, Vector2.Zero);
                this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
                this.rotation = 0.0f;
                this.effect = SpriteEffects.None;
            }
            this.damage = 2;
            this.expired = false;
            if (player.CurrentColor.Equals("Red"))
            {
            }
            else if (player.CurrentColor.Equals("Blue"))
            {
            }
            else
            {
                this.sprite = ProjectileSpriteFactory.Instance.GreenWoodSword(this.rotation, this.effect);
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
            lifeTime--;
            this.Physics.Velocity = new Vector2(this.player.Physics.Velocity.X, this.player.Physics.Velocity.Y);
            if (this.lifeTime == Extended || this.lifeTime == Retracting)
            {
                this.sprite.Update();
            }
            if (this.lifeTime <= 0 || player.DamageTimer > 0)
            {
                this.expired = true;
            }
            this.Physics.Move();
            this.Bounds = new Rectangle(this.Bounds.X + (int)this.Physics.Velocity.X, this.Bounds.Y + (int)this.Physics.Velocity.Y, this.Bounds.Width, this.Bounds.Height);
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}