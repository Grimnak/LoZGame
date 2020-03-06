using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    class ArrowProjectile : IProjectile
    {
        private static readonly int Speed = 10;
        private static readonly int LinkSize = LinkSpriteFactory.LinkHeight;
        ISprite sprite;
        private ProjectileCollisionHandler collisionHandler;
        private Rectangle frame;
        private Vector2 origin;
        private Vector2 BoundsOffset;
        private int lifeTime;
        private int projectileWidth;
        private int projectileHeight;
        private string direction;
        private readonly float rotation;
        private readonly int instance;
        private bool expired;
        private int damage;

        public int Damage { get { return damage; } set { damage = value; } }

        public bool IsExpired { get { return this.expired; } set { this.expired = value; } }

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public ArrowProjectile(Vector2 loc, string direction)
        {
            this.projectileWidth = ProjectileSpriteFactory.Instance.ArrowWidth * ProjectileSpriteFactory.Instance.Scale;
            this.projectileHeight = ProjectileSpriteFactory.Instance.StandardHeight * ProjectileSpriteFactory.Instance.Scale;
            this.collisionHandler = new ProjectileCollisionHandler(this);
            this.lifeTime = 100;
            this.damage = 1;
            this.expired = false;
            loc = new Vector2(loc.X + (LinkSize / 2), loc.Y + (LinkSize / 2));
            if (direction.Equals("Up"))
            {
                this.Physics = new Physics(new Vector2(loc.X, loc.Y - (LinkSize / 2)), new Vector2(0, -1 * Speed), new Vector2(0, 0));
                this.rotation = 0; 
                this.BoundsOffset = new Vector2(this.projectileWidth / 2, this.projectileHeight / 2);
                this.Bounds = new Rectangle((int)this.Physics.Location.X - (int)this.BoundsOffset.X, (int)this.Physics.Location.Y - (int)this.BoundsOffset.Y, projectileWidth, projectileHeight);
            }
            else if (direction.Equals("Left"))
            {
                this.Physics = new Physics(new Vector2(loc.X - (LinkSize / 2), loc.Y), new Vector2(-1 * Speed, 0), new Vector2(0, 0));
                this.rotation = -1 * MathHelper.PiOver2;
                this.BoundsOffset = new Vector2(this.projectileHeight / 2, this.projectileWidth / 2);
                this.Bounds = new Rectangle((int)this.Physics.Location.X - (int)this.BoundsOffset.X, (int)this.Physics.Location.Y - (int)this.BoundsOffset.Y, projectileHeight, projectileWidth);
            }
            else if (direction.Equals("Right"))
            {
                this.Physics = new Physics(new Vector2(loc.X + (LinkSize / 2), loc.Y), new Vector2(Speed, 0), new Vector2(0, 0));
                this.rotation = MathHelper.PiOver2;
                this.BoundsOffset = new Vector2(this.projectileHeight / 2, this.projectileWidth / 2);
                this.Bounds = new Rectangle((int)this.Physics.Location.X - (int)this.BoundsOffset.X, (int)this.Physics.Location.Y - (int)this.BoundsOffset.Y, projectileHeight, projectileWidth);
            }
            else
            {
                this.Physics = new Physics(new Vector2(loc.X, loc.Y + (LinkSize / 2)), new Vector2(0, Speed), new Vector2(0, 0));
                this.rotation = MathHelper.Pi;
                this.BoundsOffset = new Vector2(this.projectileWidth / 2, this.projectileHeight / 2);
                this.Bounds = new Rectangle((int)this.Physics.Location.X - (int)this.BoundsOffset.X, (int)this.Physics.Location.Y - (int)this.BoundsOffset.Y, projectileWidth, projectileHeight);
            }
            this.sprite = ProjectileSpriteFactory.Instance.Arrow(rotation);
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

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            collisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

        public void Update()
        {
            this.lifeTime--;
            if (this.lifeTime <= 0)
            {
                this.expired = true;
            }
            this.Bounds = new Rectangle((int)this.Physics.Location.X - (int)this.BoundsOffset.X, (int)this.Physics.Location.Y - (int)this.BoundsOffset.Y, this.Bounds.Width, this.Bounds.Height);
            this.Physics.Move();
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}
