namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class WoodenSwordProjectile : IProjectile
    {
        private static readonly int LinkSize = LinkSpriteFactory.LinkHeight;
        private Vector2 upOffset = new Vector2(2, 29);
        private Vector2 sideOffset = new Vector2(29, 4);
        private const int TotalLife = 20;
        private const int Extended = 10;
        private const int Retracting = 5;
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
            Vector2 loc = new Vector2(player.Physics.Location.X + LinkSize, player.Physics.Location.Y + LinkSize);
            this.BoundsOffset = new Vector2(this.projectileWidth, this.projectileHeight);
            if (this.direction.Equals("Up"))
            {
                this.Physics = new Physics(new Vector2(loc.X - upOffset.X, loc.Y - upOffset.Y), Vector2.Zero, Vector2.Zero);
                this.rotation = MathHelper.Pi;
            }
            else if (this.direction.Equals("Left"))
            {
                this.Physics = new Physics(new Vector2(loc.X - sideOffset.X, loc.Y + sideOffset.Y), Vector2.Zero, Vector2.Zero);
                this.rotation = 1 * MathHelper.PiOver2;
            }
            else if (this.direction.Equals("Right"))
            {
                this.Physics = new Physics(new Vector2(loc.X + sideOffset.X, loc.Y + sideOffset.Y), Vector2.Zero, Vector2.Zero);
                this.rotation = -1 * MathHelper.PiOver2;
            }
            else
            {
                this.Physics = new Physics(new Vector2(loc.X + upOffset.X, loc.Y + upOffset.Y), Vector2.Zero, Vector2.Zero);
                this.rotation = 0;
            }
            this.Bounds = new Rectangle((int)this.Physics.Location.X - (int)this.BoundsOffset.X, (int)this.Physics.Location.Y - (int)this.BoundsOffset.Y, projectileWidth, projectileHeight);
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