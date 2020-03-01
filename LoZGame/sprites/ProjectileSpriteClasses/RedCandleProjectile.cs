﻿namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class RedCandleProjectile : IProjectile
    {
        private static readonly int LinkSize = 32;
        private static readonly int LifeTimeMax = 210;
        private static readonly int FrameDelay = 10;
        private const int Speed = 10;
        private const float Accel = 0.1f;

        private readonly Texture2D Texture;      // the texture to pull frames from
        private readonly SpriteSheetData Data;
        private Rectangle firstFrame;
        private Rectangle secondFrame;
        private Rectangle currentFrame;
        private Vector2 origin;
        private Vector2 Size;
        private readonly int scale;
        private int lifeTime;
        private int travelTime;
        private float layer;
        private float rotation;

        private readonly int instance;
        private bool expired;
        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public RedCandleProjectile(Texture2D texture, SpriteSheetData data, Vector2 loc, string direction, int scale, int instance)
        {
            this.lifeTime = LifeTimeMax;
            this.Data = data;
            this.Texture = texture;
            this.Size = new Vector2(this.Data.Width * scale, this.Data.Height * scale);
            this.firstFrame = new Rectangle(0, 0, this.Data.Width, this.Data.Height);
            this.secondFrame = new Rectangle(0, this.Data.Height, this.Data.Width, this.Data.Height);
            this.currentFrame = this.firstFrame;
            this.scale = scale;
            this.instance = instance;
            this.expired = false;
            this.hostile = false;
            this.travelTime = (int)(Speed / Accel);
            this.rotation = 0;
            if (direction.Equals("Up"))
            {
                this.Physics = new Physics(new Vector2(loc.X - ((this.Size.X - LinkSize) / 2), loc.Y - LinkSize), new Vector2(0, -1 * Speed), new Vector2(0, Accel));
            }
            else if (direction.Equals("Left"))
            {
                this.Physics = new Physics(new Vector2(loc.X - LinkSize, loc.Y - ((this.Size.X - LinkSize) / 2)), new Vector2(-1 * Speed, 0), new Vector2(Accel, 0));
            }
            else if (direction.Equals("Right"))
            {
                this.Physics = new Physics(new Vector2(loc.X + LinkSize, loc.Y - ((this.Size.X - LinkSize) / 2)), new Vector2(Speed, 0), new Vector2(-1 * Accel, 0));
            }
            else
            {
                this.Physics = new Physics(new Vector2(loc.X - ((this.Size.X - LinkSize) / 2), loc.Y + LinkSize), new Vector2(0, Speed), new Vector2(0, -1 * Accel));
            }
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.layer = this.Physics.Location.Y + this.Size.Y;
        }

        public bool IsExpired => this.expired;

        public int Instance => this.instance;

        private void NextFrame()
        {
            if (this.currentFrame == this.firstFrame)
            {
                this.currentFrame = this.secondFrame;
            }
            else
            {
                this.currentFrame = this.firstFrame;
            }
        }

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
                this.NextFrame();
            }

            if (this.lifeTime >= LifeTimeMax - this.travelTime)
            {
                this.Physics.Move();
                this.Physics.Accelerate();
                this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
                this.layer = this.Physics.Location.Y + this.Size.Y;

            }
            else if (this.lifeTime <= 0)
            {
                this.expired = true;
            }
        }

        public void Draw()
        {
            LoZGame.Instance.SpriteBatch.Draw(this.Texture, this.Physics.Location, this.currentFrame, Color.White, this.rotation, this.origin, this.scale, SpriteEffects.None, this.layer);
        }
    }
}