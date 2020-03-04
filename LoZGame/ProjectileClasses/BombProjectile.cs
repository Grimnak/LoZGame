namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BombProjectile : IProjectile
    {
        private static readonly int LinkSize = 32;
        private static readonly int MaxLife = 120;
        private int lifeTime;
        private readonly int scale;
        private readonly bool isStatic;
        private bool expired;
        private readonly string direction;
        private readonly bool hostile;
        private readonly ExplosionManager explosion;
        private int projectileWidth;
        private int projectileHeight;
        private ISprite sprite;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public BombProjectile(Vector2 loc, string direction, ExplosionManager explosion)
        {
            this.projectileWidth = ProjectileSpriteFactory.Instance.StandardWidth * scale;
            this.projectileHeight = ProjectileSpriteFactory.Instance.StandardHeight * scale;
            this.lifeTime = MaxLife;
            this.direction = direction;
            this.hostile = false;
            this.explosion = explosion;
            if (this.direction == "Up")
            {
                this.Physics = new Physics(new Vector2(loc.X - ((projectileWidth - LinkSize) / 2), loc.Y - LinkSize), new Vector2(0, 0), new Vector2(0, 0));
            }
            else if (this.direction == "Left")
            {
                this.Physics = new Physics(new Vector2(loc.X - LinkSize + (LinkSize - projectileWidth), loc.Y - ((projectileHeight - LinkSize) / 2)), new Vector2(0, 0), new Vector2(0, 0));
            }
            else if (this.direction == "Right")
            {
                this.Physics = new Physics(new Vector2(loc.X + LinkSize, loc.Y - ((projectileHeight - LinkSize) / 2)), new Vector2(0, 0), new Vector2(0, 0));
            }
            else
            {
                this.Physics = new Physics(new Vector2(loc.X - ((projectileWidth - LinkSize) / 2), loc.Y + LinkSize), new Vector2(0, 0), new Vector2(0, 0));
            }

            this.isStatic = false;
            this.expired = false;
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
            this.sprite = ProjectileSpriteFactory.Instance.Bomb();
        }

        public bool IsExpired => this.expired;

        public bool IsHostile => hostile;

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.lifeTime++;
            }
        }

        public void Update()
        {
            if (!this.isStatic)
            {
                this.lifeTime--;
            }

            if (this.lifeTime <= 0)
            {
                this.sprite.Update();
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, Color.White);
        }
    }
}