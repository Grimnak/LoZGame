namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SilverArrowProjectile : IProjectile
    {
        private static readonly int Speed = 10;
        private static readonly int LinkSize = 32;
        private static readonly int scale = ProjectileSpriteFactory.Instance.Scale;

        private int lifeTime;
        private readonly string direction;
        private readonly float rotation;
        private readonly int dX;
        private readonly int dY;
        private bool expired;
        private readonly bool hostile;
        private int projectileWidth;
        private int projectileHeight;
        private ISprite sprite;

        public bool IsHostile => this.hostile;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public SilverArrowProjectile(Vector2 loc, string direction)
        {
            this.projectileWidth = ProjectileSpriteFactory.Instance.ArrowWidth * scale;
            this.projectileHeight = ProjectileSpriteFactory.Instance.StandardHeight * scale;
            this.lifeTime = 100;
            this.direction = direction;
            this.hostile = false;
            this.expired = false;
            if (this.direction.Equals("Up"))
            {
                this.Physics = new Physics(new Vector2(loc.X + (LinkSize / 2), loc.Y), new Vector2(0, -1 * Speed), new Vector2(0, 0));
                this.rotation = 0;
            }
            else if (this.direction.Equals("Left"))
            {
                this.Physics = new Physics(new Vector2(loc.X, loc.Y + (LinkSize / 2)), new Vector2(-1 * Speed, 0), new Vector2(0, 0));
                this.rotation = -1 * MathHelper.PiOver2;
            }
            else if (this.direction.Equals("Right"))
            {
                this.Physics = new Physics(new Vector2(loc.X + LinkSize, loc.Y + (LinkSize / 2)), new Vector2(Speed, 0), new Vector2(0, 0));
                this.rotation = MathHelper.PiOver2;
            }
            else
            {
                this.Physics = new Physics(new Vector2(loc.X + (LinkSize / 2), loc.Y + LinkSize), new Vector2(0, Speed), new Vector2(0, 0));
                this.rotation = MathHelper.Pi;
            }
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
            this.sprite = ProjectileSpriteFactory.Instance.SilverArrow(this.rotation);
        }

        public bool IsExpired => this.expired;

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                // do nothing
            }
            else
            {
                this.lifeTime = 0;
            }
        }

        public void Update()
        {
            this.lifeTime--;
            if (this.lifeTime <= 0)
            {
                this.expired = true;
            }
            this.Physics.Move();
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, Color.White);
        }
    }
}