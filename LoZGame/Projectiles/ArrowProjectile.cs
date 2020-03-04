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

        private Rectangle frame;
        private Vector2 origin;
        private int lifeTime;
        private int projectileWidth;
        private int projectileHeight;
        private string direction;
        private readonly float rotation;
        private readonly int instance;
        private bool expired;
        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        public bool IsExpired => this.expired;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public ArrowProjectile(Vector2 loc, string direction)
        {
            this.projectileWidth = ProjectileSpriteFactory.Instance.ArrowWidth * ProjectileSpriteFactory.Instance.Scale;
            this.projectileHeight = ProjectileSpriteFactory.Instance.StandardHeight * ProjectileSpriteFactory.Instance.Scale;
            this.lifeTime = 100;
            this.hostile = false;
            this.expired = false;
            if (direction.Equals("Up"))
            {
                this.Physics = new Physics(new Vector2(loc.X + (LinkSize / 2), loc.Y), new Vector2(0, -1 * Speed), new Vector2(0, 0));
                this.rotation = 0;
            }
            else if (direction.Equals("Left"))
            {
                this.Physics = new Physics(new Vector2(loc.X, loc.Y + (LinkSize / 2)), new Vector2(-1 * Speed, 0), new Vector2(0, 0));
                this.rotation = -1 * MathHelper.PiOver2;
            }
            else if (direction.Equals("Right"))
            {
                this.Physics = new Physics(new Vector2(loc.X + LinkSize, loc.Y + (LinkSize / 2)), new Vector2(Speed, 0), new Vector2(0, 0));
                this.rotation = MathHelper.PiOver2;
            }
            else
            {
                this.Physics = new Physics(new Vector2(loc.X + (LinkSize / 2), loc.Y + LinkSize), new Vector2(0, Speed), new Vector2(0, 0));
                this.rotation = MathHelper.Pi;
            }
            this.sprite = ProjectileSpriteFactory.Instance.Arrow(rotation);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer || otherCollider is IBlock)
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
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
            this.Physics.Move();
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, Color.White);
        }
    }
}
