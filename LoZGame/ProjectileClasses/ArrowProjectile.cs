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
        private static readonly int LinkSize = 30;
        ISprite sprite;

        private Rectangle frame;
        private Vector2 origin;
        private int lifeTime;
        private string direction;
        private readonly float rotation;
        private readonly int dX;
        private readonly int dY;
        private readonly int instance;
        private bool expired;
        private readonly bool hostile;
        private Vector2 Size;

        public bool IsHostile => this.hostile;

        public bool IsExpired => this.expired;

        public int Instance => this.instance;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public ArrowProjectile(Vector2 loc, string direction, int scale, int instance)
        {
            this.lifeTime = 100;
            this.hostile = false;
            this.instance = instance;
            this.expired = false;
            this.Size = new Vector2(ProjectileSpriteFactory.Instance.ArrowWidth * scale, ProjectileSpriteFactory.Instance.StandardHeight * scale);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
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
            this.sprite = ProjectileSpriteFactory.Instance.Arrow(Physics.Location, direction, scale, instance);
        }

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
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.Physics.Move();
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, Color.White);
        }
    }
}
