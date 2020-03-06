namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SwordBeamExplosion : IProjectile
    {
        private int lifeTime;
        private readonly int scale = ProjectileSpriteFactory.Instance.Scale;
        private readonly string direction;
        private readonly float rotation;
        private bool expired;
        private readonly SpriteEffects effect;
        private ISprite sprite;
        private int projectileWidth;
        private int projectileHeight;
        private ProjectileCollisionHandler collisionHandler;
        private int damage;

        public int Damage { get { return damage; } set { damage = value; } }

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        private static readonly int FrameDelay = 4;
        private static readonly float Speed = 2.5F;
        private static readonly int MaxLifeTime = 60;

        public SwordBeamExplosion(Vector2 location, string direction)
        {
            this.lifeTime = MaxLifeTime;
            this.collisionHandler = new ProjectileCollisionHandler(this);
            projectileWidth = ProjectileSpriteFactory.Instance.StandardWidth * scale;
            projectileHeight = ProjectileSpriteFactory.Instance.SwordBeamExplosionHeight * scale;
            this.direction = direction;
            this.Physics = new Physics(new Vector2(location.X - projectileWidth, location.Y - projectileHeight), new Vector2(0, 0), new Vector2(0, 0));
            if (this.direction.Equals("NorthEast"))
            {
                this.Physics.Velocity = new Vector2(Speed, -1 * Speed);
                this.effect = SpriteEffects.FlipHorizontally;
                this.rotation = 0;
            }
            else if (this.direction.Equals("NorthWest"))
            {
                this.Physics.Velocity = new Vector2(-1 * Speed, -1 * Speed);
                this.effect = SpriteEffects.None;
                this.rotation = 0;
            }
            else if (this.direction.Equals("SouthEast"))
            {
                this.Physics.Velocity = new Vector2(Speed, Speed);
                this.Physics.Location = new Vector2(this.Physics.Location.X + projectileWidth, this.Physics.Location.Y + projectileHeight);
                this.effect = SpriteEffects.None;
                this.rotation = MathHelper.Pi;
            }
            else
            {
                this.rotation = 0;
                this.Physics.Velocity = new Vector2(-1 * Speed, Speed);
                this.effect = SpriteEffects.FlipVertically;
            }
            this.damage = 1;
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
            this.hostile = false;
            this.expired = false;
            this.sprite = ProjectileSpriteFactory.Instance.SwordExplosion(this.effect, this.rotation);
        }

        public bool IsExpired { get { return this.expired; } set { this.expired = value; } }

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
            if (this.lifeTime % FrameDelay == 0)
            {
                this.sprite.Update();
            }

            if (this.lifeTime <= 0)
            {
                this.expired = true;
            }
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
            this.Physics.Move();
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, Color.White);
        }
    }
}