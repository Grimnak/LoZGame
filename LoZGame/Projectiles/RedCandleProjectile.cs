namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class RedCandleProjectile : IProjectile
    {
        private static readonly int LinkSize = 32;
        private static readonly int LifeTimeMax = 500;
        private static readonly int FrameDelay = 10;
        private static readonly int scale = ProjectileSpriteFactory.Instance.Scale;
        private const int Speed = 4;
        private const float Accel = 0.2f;
        private const float AccelDecay = 0.95f;

        private int lifeTime;
        private int travelTime;

        private bool expired;
        private readonly bool hostile;
        private int projectileWidth;
        private int projectileHeight;
        ISprite sprite;

        public bool IsHostile => this.hostile;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public RedCandleProjectile(Vector2 loc, string direction)
        {
            this.lifeTime = LifeTimeMax;
            this.projectileWidth = ProjectileSpriteFactory.Instance.FlameWidth * scale;
            this.projectileHeight = ProjectileSpriteFactory.Instance.FlameHeight * scale;
            this.expired = false;
            this.hostile = false;
            this.travelTime = (int)(LifeTimeMax / 2);
            if (direction.Equals("Up"))
            {
                this.Physics = new Physics(new Vector2(loc.X + ((LinkSize - projectileWidth) / 2), loc.Y - LinkSize), new Vector2(0, -1 * Speed), new Vector2(0, Accel));
            }
            else if (direction.Equals("Left"))
            {
                this.Physics = new Physics(new Vector2(loc.X - LinkSize, loc.Y + ((LinkSize - projectileHeight) / 2)), new Vector2(-1 * Speed, 0), new Vector2(Accel, 0));
            }
            else if (direction.Equals("Right"))
            {
                this.Physics = new Physics(new Vector2(loc.X + LinkSize, loc.Y + ((LinkSize - projectileHeight) / 2)), new Vector2(Speed, 0), new Vector2(-1 * Accel, 0));
            }
            else
            {
                this.Physics = new Physics(new Vector2(loc.X + ((LinkSize - projectileWidth) / 2), loc.Y + LinkSize), new Vector2(0, Speed), new Vector2(0, -1 * Accel));
            }
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
            this.sprite = ProjectileSpriteFactory.Instance.RedCandle();
        }

        public bool IsExpired => this.expired;

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                // do nothing
            } else
            {
                this.Physics.StopMovement();
            }
        }

        public void Update()
        {
            this.lifeTime--;
            if (this.lifeTime % FrameDelay == 0)
            {
                this.sprite.Update();
            }

            if (this.lifeTime >= LifeTimeMax - this.travelTime)
            {
                this.Physics.Move();
                this.Physics.Accelerate();
                this.Physics.Acceleration = new Vector2(this.Physics.Acceleration.X * AccelDecay, this.Physics.Acceleration.Y * AccelDecay);
                this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
            }
            else if (this.lifeTime <= 0)
            {
                this.expired = true;
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, Color.White);
        }
    }
}