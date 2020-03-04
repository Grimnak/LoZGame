namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public class ItemCollisionHandler
    {
        private IItem item;

        public ItemCollisionHandler(IItem item)
        {
            this.item = item;
        }

        public void OnCollisionResponse(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
             this.item.Expired = true;
        }
    }
}