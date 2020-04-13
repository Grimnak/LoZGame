namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    internal class Health : ItemEssentials, IItem
    {
        public Health(Vector2 loc)
        {
            this.Sprite = ItemSpriteFactory.Instance.Health();
            this.FrameDelay = 5;
            this.itemCollisionHandler = new ItemCollisionHandler(this);
            this.Physics = new Physics(loc);
            this.PickUpItemTime = -1;
            this.LifeTime = 0;
            Vector2 size = new Vector2(ItemSpriteFactory.RupeeWidth * ItemSpriteFactory.Instance.Scale, ItemSpriteFactory.RupeeHeight * ItemSpriteFactory.Instance.Scale);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)size.X, (int)size.Y);
            this.Expired = false;
        }
    }
}