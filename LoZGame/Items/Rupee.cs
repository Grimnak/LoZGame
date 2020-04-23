﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    internal class Rupee : ItemEssentials, IItem
    {
        public Rupee(Vector2 loc)
        {
            Sprite = ItemSpriteFactory.Instance.Rupee();
            itemCollisionHandler = new ItemCollisionHandler(this);
            Physics = new Physics(loc);
            PickUpItemTime = -1;
            LifeTime = 0;
            Vector2 size = new Vector2(ItemSpriteFactory.RupeeWidth * ItemSpriteFactory.Instance.Scale, ItemSpriteFactory.RupeeHeight * ItemSpriteFactory.Instance.Scale);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, (int)size.X, (int)size.Y);
            Expired = false;
        }
    }
}