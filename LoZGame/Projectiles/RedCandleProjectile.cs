namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class RedCandleProjectile : IProjectile
    {
        private static readonly int LinkSize = LinkSpriteFactory.LinkHeight;
        private static readonly int LifeTimeMax = 500;
        private static readonly int FrameDelay = 10;
        private static readonly int scale = ProjectileSpriteFactory.Instance.Scale / 2;
        private const int Speed = 4;
        private const float Accel = 0.2f;
        private const float AccelDecay = 0.95f;
        private ProjectileCollisionHandler collisionHandler;
        private int lifeTime;
        private int travelTime;

        private bool expired;
        private int projectileWidth;
        private int projectileHeight;
        ISprite sprite;
        private int damage;

        public int StunDuration { get { return 0; } set {/*do nothing*/} }

        public bool Returning { get { return false; } set {/*do nothing*/} }

        public int Damage { get { return damage; } set { damage = value; } }

        public Physics Physics { get; set; }

        

        public RedCandleProjectile(Vector2 loc, string direction)
        {
            this.lifeTime = LifeTimeMax;
            this.projectileWidth = ProjectileSpriteFactory.Instance.FlameWidth * scale;
            this.projectileHeight = ProjectileSpriteFactory.Instance.FlameHeight * scale;
            this.collisionHandler = new ProjectileCollisionHandler(this);
            this.expired = false;
            this.travelTime = (int)(LifeTimeMax / 2);
            if (direction.Equals("Up"))
            {
                this.Physics = new Physics(new Vector2(loc.X + ((LinkSize - projectileWidth) / 2), loc.Y - projectileHeight));
                this.Physics.MovementVelocity = new Vector2(0, -1 * Speed);
                this.Physics.MovementAcceleration = new Vector2(0, Accel);
            }
            else if (direction.Equals("Left"))
            {
                this.Physics = new Physics(new Vector2(loc.X - projectileWidth, loc.Y - ((LinkSize - projectileHeight) / 2)));
                this.Physics.MovementVelocity = new Vector2(-1 * Speed, 0);
                this.Physics.MovementAcceleration = new Vector2(Accel, 0);
            }
            else if (direction.Equals("Right"))
            {
                this.Physics = new Physics(new Vector2(loc.X + LinkSize, loc.Y - ((LinkSize - projectileHeight) / 2)));
                this.Physics.MovementVelocity = new Vector2(Speed, 0);
                this.Physics.MovementAcceleration = new Vector2(-1 * Accel, 0);
            }
            else
            {
                this.Physics = new Physics(new Vector2(loc.X + ((LinkSize - projectileWidth) / 2), loc.Y + LinkSize));
                this.Physics.MovementVelocity = new Vector2(0, Speed);
                this.Physics.MovementAcceleration = new Vector2(0, -1 * Accel);
            }
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
            this.sprite = ProjectileSpriteFactory.Instance.RedCandle();
            this.damage = 10;
        }

        public bool IsExpired { get { return this.expired; } set { this.expired = value; } }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IEnemy)
            {
                this.collisionHandler.OnCollisionResponse((IEnemy)otherCollider, collisionSide);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            collisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
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
                this.Physics.MovementAcceleration = new Vector2(this.Physics.MovementAcceleration.X * AccelDecay, this.Physics.MovementAcceleration.Y * AccelDecay);
            }
            else if (this.lifeTime <= 0)
            {
                this.expired = true;
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}