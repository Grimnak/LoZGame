﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    internal class DroppedYellowRupee : IItem
    {
        private static readonly int DespawnTimer = LoZGame.Instance.UpdateSpeed * 20;
        private static readonly int SpawnTimer = LoZGame.Instance.UpdateSpeed * 20;
        private ISprite sprite;
        private ItemCollisionHandler itemCollisionHandler;

        private readonly Texture2D Texture;      // the texture to pull frames from
        private Vector2 Size;
        private float layer;
        private int lifeTime;
        private bool expired;

        public int PickUpItemTime { get { return 0; } }

        public bool Expired { get { return this.expired; } set { this.expired = value; } }

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public DroppedYellowRupee(Vector2 loc)
        {
            this.sprite = ItemSpriteFactory.Instance.YellowRupee(ItemSpriteFactory.Instance.Scale);
            this.itemCollisionHandler = new ItemCollisionHandler(this);
            this.Physics = new Physics(loc, new Vector2(0, -1), new Vector2(0, 0.1f));
            this.Size = new Vector2(ItemSpriteFactory.RupeeWidth * ItemSpriteFactory.Instance.Scale, ItemSpriteFactory.RupeeHeight * ItemSpriteFactory.Instance.Scale);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.lifeTime = 0;
            this.expired = false;
            this.itemCollisionHandler = new ItemCollisionHandler(this);
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
                this.itemCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
        }

        public void ReverseBob()
        {
            this.Physics.Acceleration = new Vector2(0, this.Physics.Acceleration.Y * -1);
        }

        public void Update()
        {
            this.lifeTime++;
            this.Physics.Move();
            this.Physics.Accelerate();
            if (this.lifeTime >= DespawnTimer)
            {
                this.expired = true;
            }
            if (this.lifeTime % 20 == 0)
            {
                this.ReverseBob();
            }
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.sprite.Update();
        }

        public void Draw(Color spriteTint)
        {
            if ((this.lifeTime > SpawnTimer && this.lifeTime < (DespawnTimer - (4 * SpawnTimer))) || this.lifeTime % 4 < 2)
            {
                this.sprite.Draw(this.Physics.Location, spriteTint);
            }
        }
    }
}