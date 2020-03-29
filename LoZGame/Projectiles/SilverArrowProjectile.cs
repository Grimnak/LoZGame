﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SilverArrowProjectile : IProjectile
    {
        private static readonly int Speed = 10;
        private static readonly int LinkSize = LinkSpriteFactory.LinkHeight;
        private static readonly int scale = ProjectileSpriteFactory.Instance.Scale;
        private Vector2 BoundsOffset;
        private ProjectileCollisionHandler collisionHandler;
        private readonly string direction;
        private readonly float rotation;
        private bool expired;
        private int projectileWidth;
        private int projectileHeight;
        private ISprite sprite;
        private int damage;

        public int StunDuration { get { return 0; } set {/*do nothing*/} }

        public bool Returning { get { return false; } set {/*do nothing*/} }

        public int Damage { get { return damage; } set { damage = value; } }

        public Physics Physics { get; set; }

        

        public SilverArrowProjectile(Vector2 loc, string direction)
        {
            this.projectileWidth = ProjectileSpriteFactory.Instance.ArrowWidth * scale;
            this.projectileHeight = ProjectileSpriteFactory.Instance.StandardHeight * scale;
            this.collisionHandler = new ProjectileCollisionHandler(this);
            this.expired = false;
            loc = new Vector2(loc.X + (LinkSize / 2), loc.Y + (LinkSize / 2));
            if (direction.Equals("Up"))
            {
                this.Physics = new Physics(new Vector2(loc.X, loc.Y - (LinkSize / 2)));
                this.Physics.MovementVelocity = new Vector2(0, -1 * Speed);
                this.Physics.MovementAcceleration = Vector2.Zero;
                this.rotation = 0;
                this.BoundsOffset = new Vector2(this.projectileWidth / 2, this.projectileHeight / 2);
                this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X - (int)this.BoundsOffset.X, (int)this.Physics.Location.Y - (int)this.BoundsOffset.Y, projectileWidth, projectileHeight);
            }
            else if (direction.Equals("Left"))
            {
                this.Physics = new Physics(new Vector2(loc.X - (LinkSize / 2), loc.Y));
                this.Physics.MovementVelocity = new Vector2(-1 * Speed, 0);
                this.Physics.MovementAcceleration = Vector2.Zero;
                this.rotation = -1 * MathHelper.PiOver2;
                this.BoundsOffset = new Vector2(this.projectileHeight / 2, this.projectileWidth / 2);
                this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X - (int)this.BoundsOffset.X, (int)this.Physics.Location.Y - (int)this.BoundsOffset.Y, projectileHeight, projectileWidth);
            }
            else if (direction.Equals("Right"))
            {
                this.Physics = new Physics(new Vector2(loc.X + (LinkSize / 2), loc.Y));
                this.Physics.MovementVelocity = new Vector2(Speed, 0);
                this.Physics.MovementAcceleration = Vector2.Zero;
                this.rotation = MathHelper.PiOver2;
                this.BoundsOffset = new Vector2(this.projectileHeight / 2, this.projectileWidth / 2);
                this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X - (int)this.Physics.Location.X, (int)this.Physics.Location.Y - (int)this.BoundsOffset.Y, projectileHeight, projectileWidth);
            }
            else
            {
                this.Physics = new Physics(new Vector2(loc.X, loc.Y + (LinkSize / 2)));
                this.Physics.MovementVelocity = new Vector2(0, Speed);
                this.Physics.MovementAcceleration = Vector2.Zero;
                this.rotation = MathHelper.Pi;
                this.BoundsOffset = new Vector2(this.projectileWidth / 2, this.projectileHeight / 2);
                this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X - (int)this.BoundsOffset.X, (int)this.Physics.Location.Y - (int)this.BoundsOffset.Y, projectileWidth, projectileHeight);
            }
            this.damage = 8;
            this.sprite = ProjectileSpriteFactory.Instance.SilverArrow(this.rotation);
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
            this.Physics.Move();
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}