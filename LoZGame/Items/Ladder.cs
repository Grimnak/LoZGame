namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    internal class Ladder : ItemEssentials, IItem
    {
        public Ladder(Vector2 loc)
        {
            this.Sprite = ItemSpriteFactory.Instance.Ladder();
            this.itemCollisionHandler = new ItemCollisionHandler(this);
            this.Physics = new Physics(loc);
            this.PickUpItemTime = LoZGame.Instance.UpdateSpeed;
            this.LifeTime = 0;
            Vector2 size = new Vector2(ItemSpriteFactory.LadderWidth * ItemSpriteFactory.Instance.Scale, ItemSpriteFactory.LadderHeight * ItemSpriteFactory.Instance.Scale);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)size.X, (int)size.Y);
            this.Expired = false;
        }
    }
}