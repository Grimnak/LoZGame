﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    internal class Compass : IItem
    {
        
        private ISprite sprite;
        private ItemCollisionHandler itemCollisionHandler;

        private readonly Texture2D Texture;      // the texture to pull frames from
        private Vector2 Size;
        private float layer;
        private int lifeTime;
        private bool expired;

        public bool Expired { get { return this.expired; } set { this.expired = value; } }

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public Compass(Vector2 loc)
        {
            this.sprite = ItemSpriteFactory.Instance.Compass(ItemSpriteFactory.Instance.Scale);
            this.itemCollisionHandler = new ItemCollisionHandler(this);
            this.Physics = new Physics(loc, new Vector2(0, -1), new Vector2(0, 0.1f));
            this.Size = new Vector2(ItemSpriteFactory.CompassWidth * ItemSpriteFactory.Instance.Scale, ItemSpriteFactory.CompassHeight * ItemSpriteFactory.Instance.Scale);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.lifeTime = 0;
            this.expired = false;
        }

        private void UpdateLoc()
        {
            if ((int)Math.Abs(this.Physics.Velocity.X) > 0 || (int)Math.Abs(this.Physics.Velocity.Y) > 0)
            {
                this.Physics.Move();
                this.Physics.Accelerate();
            }
            else
            {
                this.Physics.StopMovement();
            }
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
            this.lifeTime++;
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.UpdateLoc();
            this.sprite.Update();
        }

        public void Draw(Color spriteTint)
        {
            this.sprite.Draw(this.Physics.Location, spriteTint);
        }
    }
}