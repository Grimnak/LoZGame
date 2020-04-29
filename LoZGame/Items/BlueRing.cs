namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    internal class BlueRing : ItemEssentials, IItem
    {
        public BlueRing(Vector2 loc)
        {
            Sprite = ItemSpriteFactory.Instance.BlueRing();
            itemCollisionHandler = new ItemCollisionHandler(this);
            Physics = new Physics(loc);
            PickUpItemTime = LoZGame.Instance.UpdateSpeed;
            LifeTime = 0;
            Vector2 size = new Vector2(ItemSpriteFactory.RingWidth, ItemSpriteFactory.RingHeight);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, (int)size.X, (int)size.Y);
            Expired = false;
        }
    }
}