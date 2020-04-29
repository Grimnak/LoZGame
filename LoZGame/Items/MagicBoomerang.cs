namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class MagicBoomerang : ItemEssentials, IItem
    {
        public MagicBoomerang(Vector2 loc)
        {
            Sprite = ItemSpriteFactory.Instance.MagicBoomerang();
            itemCollisionHandler = new ItemCollisionHandler(this);
            Physics = new Physics(loc);
            PickUpItemTime = LoZGame.Instance.UpdateSpeed;
            LifeTime = 0;
            Vector2 size = new Vector2(ItemSpriteFactory.BoomerangWidth, ItemSpriteFactory.BoomerangHeight);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, (int)size.X, (int)size.Y);
            Expired = false;
        }
    }
}