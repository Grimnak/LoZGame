﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    using Microsoft.Xna.Framework;
    class DragonFireBall : IProjectile
    {
        private const int FrameChange = 15;
        private const int XVelocity = 3;
        private const int YVelocity = 1;
        private const int MaxLife = 300;

        ISprite sprite;
        private int lifeTime;
        private string direction;
        private readonly float rotation;
        private bool expired;
        private Vector2 Size;

        public bool IsExpired => this.expired;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public DragonFireBall(Vector2 loc, string direction)
        {
            if (direction.Equals("NorthWest"))
            {
                this.Physics = new Physics(new Vector2(loc.X, loc.Y), new Vector2(-1 * XVelocity, -1 * YVelocity), new Vector2(0, 0));
            }
            else if (direction.Equals("West"))
            {
                this.Physics = new Physics(new Vector2(loc.X, loc.Y ), new Vector2(-1 * XVelocity, 0), new Vector2(0, 0));
            }
            else if (direction.Equals("SouthWest"))
            {
                this.Physics = new Physics(new Vector2(loc.X, loc.Y), new Vector2(-1 * XVelocity, YVelocity), new Vector2(0, 0));
            }
            float size = (ProjectileSpriteFactory.Instance.FireballHeight * ProjectileSpriteFactory.Instance.Scale) * 1.5f;
            this.Size = new Vector2(size, size);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.sprite = ProjectileSpriteFactory.Instance.Fireball();
            this.expired = false;
            this.lifeTime = MaxLife;
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.expired = true;
            }
        }

        public void Update()
        {
            this.lifeTime--;
            if (this.lifeTime <= 0)
            {
                this.expired = true;
            }
            if (this.lifeTime % FrameChange == 0)
            {
                this.sprite.Update();
            }
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.Physics.Move();
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}