﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    internal class MagicBook : IItem
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

        public MagicBook(Vector2 loc)
        {
            this.sprite = ItemSpriteFactory.Instance.MagicBook(loc, ItemSpriteFactory.Instance.Scale);
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