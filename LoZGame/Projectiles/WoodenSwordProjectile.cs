namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class WoodenSwordProjectile : IProjectile
    {
        private static readonly int LinkSize = LinkSpriteFactory.LinkHeight;
        private const int YOffset = 10;
        private const int XOffset = 8;
        private const int TotalLife = 60;
        private const int Extended = 50;
        private const int Retracting = 30;
        private ProjectileCollisionHandler collisionHandler;

        private int lifeTime;
        private Vector2 BoundsOffset;
        private readonly string direction;
        private readonly float rotation;
        private bool expired;
        private ISprite sprite;
        private int projectileWidth;
        private int projectileHeight;
        private int damage;

        public int Damage { get { return damage; } set { damage = value; } }

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        private static readonly int FrameDelay = 4;
        private const int Speed = 5;
        private static readonly int XBound = 800;
        private static readonly int YBound = 480;

        public WoodenSwordProjectile(IPlayer player)
        {
            this.projectileWidth = ProjectileSpriteFactory.Instance.SwordWidth;
            this.projectileHeight = ProjectileSpriteFactory.Instance.SwordHeight;             
            this.collisionHandler = new ProjectileCollisionHandler(this);
            this.lifeTime = TotalLife;
            this.direction = player.CurrentDirection;
            Vector2 loc = new Vector2(player.Physics.Location.X + (LinkSpriteFactory.LinkWidth / 2), player.Physics.Location.Y + (LinkSpriteFactory.LinkHeight / 2));

            if (this.direction.Equals("Up"))
            {
                this.Physics = new Physics(new Vector2(400, 240), Vector2.Zero, Vector2.Zero);
                //this.Physics = new Physics(new Vector2(loc.X, loc.Y - (LinkSize / 3)), Vector2.Zero, Vector2.Zero);
                this.rotation = MathHelper.Pi;
                this.BoundsOffset = new Vector2(this.projectileWidth / 2, this.projectileHeight / 2);
                this.Bounds = new Rectangle((int)this.Physics.Location.X - (int)this.BoundsOffset.X, (int)this.Physics.Location.Y - (int)this.BoundsOffset.Y, projectileWidth, projectileHeight);
            }
            else if (this.direction.Equals("Left"))
            {
                this.Physics = new Physics(new Vector2(loc.X - (LinkSize / 2), loc.Y), Vector2.Zero, Vector2.Zero);
                this.rotation = 1 * MathHelper.PiOver2;
                this.BoundsOffset = new Vector2(this.projectileHeight / 2, this.projectileWidth / 2);
                this.Bounds = new Rectangle((int)this.Physics.Location.X - (int)this.BoundsOffset.X, (int)this.Physics.Location.Y - (int)this.BoundsOffset.Y, projectileHeight, projectileWidth);
            }
            else if (this.direction.Equals("Right"))
            {
                this.Physics = new Physics(new Vector2(loc.X + (LinkSize / 2), loc.Y), Vector2.Zero, Vector2.Zero);
                this.rotation = -1 * MathHelper.PiOver2;
                this.BoundsOffset = new Vector2(this.projectileHeight / 2, this.projectileWidth / 2);
                this.Bounds = new Rectangle((int)this.Physics.Location.X - (int)this.BoundsOffset.X, (int)this.Physics.Location.Y - (int)this.BoundsOffset.Y, projectileHeight, projectileWidth);
            }
            else
            {
                this.Physics = new Physics(new Vector2(loc.X, loc.Y + (LinkSize / 3)), Vector2.Zero, Vector2.Zero);
                this.rotation = 0;
                this.BoundsOffset = new Vector2(this.projectileWidth / 2, this.projectileHeight / 2);
                this.Bounds = new Rectangle((int)this.Physics.Location.X - (int)this.BoundsOffset.X, (int)this.Physics.Location.Y - (int)this.BoundsOffset.Y, projectileWidth, projectileHeight);
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
                this.sprite = ProjectileSpriteFactory.Instance.GreenWoodSword(this.rotation);
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
            if (this.lifeTime == Extended || this.lifeTime == Retracting)
            {
                this.sprite.Update();
            }
            if (this.lifeTime <= 0)
            {
                this.expired = true;
            }
            this.Bounds = new Rectangle((int)this.Physics.Location.X - (int)this.BoundsOffset.X, (int)this.Physics.Location.Y - (int)this.BoundsOffset.Y, this.Bounds.Width, this.Bounds.Height);
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}