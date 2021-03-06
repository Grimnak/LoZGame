﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    internal class Triforce : ItemEssentials, IItem
    {
        public Triforce(Vector2 loc)
        {
            Sprite = ItemSpriteFactory.Instance.Triforce();
            FrameDelay = 5;
            itemCollisionHandler = new ItemCollisionHandler(this);
            Physics = new Physics(loc);
            PickUpItemTime = 440;
            LifeTime = 0;
            Vector2 size = new Vector2(ItemSpriteFactory.TriforceWidth, ItemSpriteFactory.TriforceHeight);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, (int)size.X, (int)size.Y);
            Expired = false;
        }
    }
}