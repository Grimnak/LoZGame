﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    internal class Flute : IItem
    {
        IItemSprite sprite;

        public Physics Physics
        {
            get { return this.sprite.Physics; }
            set { this.sprite.Physics = value; }
        }

        public Rectangle Bounds
        {
            get { return this.sprite.Bounds; }
            set { this.sprite.Bounds = value; }
        }

        public Flute(Vector2 loc)
        {
            this.sprite = ItemSpriteFactory.Instance.Flute(loc, ItemSpriteFactory.Instance.Scale);
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            this.sprite.OnCollisionResponse(otherCollider, collisionSide);
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw();
        }
    }
}