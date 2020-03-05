namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SwordBeamProjectile : IProjectile
    {
        private const int LinkSize = 26;
        private const int Offset = 4;
        private const int Delay = 10;

        private ProjectileCollisionHandler collisionHandler;

        private int lifeTime;
        private readonly int scale = ProjectileSpriteFactory.Instance.Scale;
        private readonly string direction;
        private readonly float rotation;
        private readonly int instance;
        private bool expired;
        private Vector2 tip;
        private Vector2 origin;
        private ISprite sprite;
        private int projectileWidth;
        private int projectileHeight;
        private int damage;

        public int Damage { get { return damage; } set { damage = value; } }

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        private static readonly int FrameDelay = 4;
        private const int Speed = 5;
        private static readonly int MaxLifeTime = 40;
        private static readonly int XBound = 800;
        private static readonly int YBound = 480;

        public SwordBeamProjectile(IPlayer player)
        {
            this.projectileWidth = ProjectileSpriteFactory.Instance.StandardWidth * scale;
            this.projectileHeight = ProjectileSpriteFactory.Instance.TriforceSize * scale;
            this.collisionHandler = new ProjectileCollisionHandler(this);
            this.lifeTime = MaxLifeTime;
            this.direction = player.CurrentDirection;
            Vector2 loc = player.Physics.Location;
            this.hostile = false;

            if (this.direction.Equals("Up"))
            {
                this.Physics = new Physics(new Vector2(loc.X + (LinkSize - Offset - (projectileWidth / 2)), loc.Y), new Vector2(0, -1 * Speed), new Vector2(0, 0));
                this.rotation = MathHelper.Pi;
                this.tip = new Vector2(projectileWidth, 0);
            }
            else if (this.direction.Equals("Left"))
            {
                this.Physics = new Physics(new Vector2(loc.X, loc.Y + (LinkSize - (projectileWidth / 2))), new Vector2(-1 * Speed, 0), new Vector2(0, 0));
                this.rotation = 1 * MathHelper.PiOver2;
                this.tip = new Vector2(-1 * Offset, projectileWidth / 2);
            }
            else if (this.direction.Equals("Right"))
            {
                this.Physics = new Physics(new Vector2(loc.X + LinkSize, loc.Y + (LinkSize - (projectileWidth / 2))), new Vector2(Speed, 0), new Vector2(0, 0));
                this.rotation = -1 * MathHelper.PiOver2;
                this.tip = new Vector2(projectileHeight, projectileWidth / 2);
            }
            else
            {
                this.Physics = new Physics(new Vector2(loc.X + (LinkSize - (projectileWidth / 2)), loc.Y + LinkSize), new Vector2(0, Speed), new Vector2(0, 0));
                this.rotation = 0;
                this.tip = new Vector2(projectileWidth / 2, projectileHeight);
            }
            this.damage = 10;
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
            this.expired = false;
            this.sprite = ProjectileSpriteFactory.Instance.SwordBeam(this.rotation);
        }

        public bool IsExpired { get { return this.expired; } set { this.expired = value; } }

        public int Instance => this.instance;

        private void CheckBounds()
        {
            if (this.Physics.Location.X >= XBound - this.tip.X || this.Physics.Location.X <= 0 || this.Physics.Location.Y >= YBound - this.tip.Y || this.Physics.Location.Y <= 0)
            {
                this.lifeTime = 0;
            }
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IEnemy)
            {
                this.collisionHandler.OnCollisionResponse((IEnemy)otherCollider, collisionSide);
            } 
            else if (otherCollider is IBlock)
            {
                this.collisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
            else if (otherCollider is IPlayer)
            {
                this.collisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IItem)
            {
                this.collisionHandler.OnCollisionResponse((IItem)otherCollider, collisionSide);
            }
            else if (otherCollider is IDoor)
            {
                this.collisionHandler.OnCollisionResponse((IDoor)otherCollider, collisionSide);
            }
        }

        public void Update()
        {
            this.lifeTime--;
            if (this.lifeTime < MaxLifeTime - Delay)
            {
                if (this.lifeTime % FrameDelay == 0)
                {
                    this.sprite.Update();
                }

                if (this.lifeTime <= 0)
                {
                    int explosionType = LoZGame.Instance.Entities.ExplosionManager.SwordExplosion;
                    Vector2 explosionLocation = new Vector2(this.Physics.Location.X + this.tip.X, this.Physics.Location.Y + this.tip.Y);
                    LoZGame.Instance.Entities.ExplosionManager.AddExplosion(explosionType, explosionLocation);
                    this.expired = true;
                }

                this.Physics.Move();
                this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
                this.CheckBounds();
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, Color.White);
        }
    }
}