﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    internal class Key : ItemEssentials, IItem
    {
        public Key(Vector2 loc)
        {
            SoundFactory.Instance.PlayKeyAppears();
            this.Sprite = ItemSpriteFactory.Instance.Key();
            this.itemCollisionHandler = new ItemCollisionHandler(this);
            this.Physics = new Physics(loc);
            this.PickUpItemTime = LoZGame.Instance.UpdateSpeed;
            this.LifeTime = 0;
            Vector2 size = new Vector2(ItemSpriteFactory.RupeeWidth * ItemSpriteFactory.Instance.Scale, ItemSpriteFactory.RupeeHeight * ItemSpriteFactory.Instance.Scale);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)size.X, (int)size.Y);
            this.Expired = false;
            this.StartBob();
        }
    }
}