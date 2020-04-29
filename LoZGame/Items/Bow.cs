namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    internal class Bow : ItemEssentials, IItem
    {
        public Bow(Vector2 loc)
        {
            Sprite = ItemSpriteFactory.Instance.Bow();
            itemCollisionHandler = new ItemCollisionHandler(this);
            Physics = new Physics(loc);
            PickUpItemTime = LoZGame.Instance.UpdateSpeed;
            LifeTime = 0;
            Vector2 size = new Vector2(ItemSpriteFactory.BowWidth, ItemSpriteFactory.BowHeight);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, (int)size.X, (int)size.Y);
            Expired = false;
        }
    }
}