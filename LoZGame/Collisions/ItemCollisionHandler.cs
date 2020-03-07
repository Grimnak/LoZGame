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
            if (this.item.PickUpItemTime == -1) 
            {
                this.item.Expired = true;
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            if (collisionSide == CollisionDetection.CollisionSide.Right)
            {
                this.item.Physics.Location = new Vector2(LoZGame.Instance.GraphicsDevice.Viewport.Width - sourceWidth - BlockSpriteFactory.Instance.HorizontalOffset + 10, this.item.Physics.Location.Y);
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Left)
            {
                this.item.Physics.Location = new Vector2(BlockSpriteFactory.Instance.HorizontalOffset, this.item.Physics.Location.Y);
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Bottom)
            {
                this.item.Physics.Location = new Vector2(this.item.Physics.Location.X, LoZGame.Instance.GraphicsDevice.Viewport.Height - sourceHeight - BlockSpriteFactory.Instance.VerticalOffset);
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Top)
            {
                this.item.Physics.Location = new Vector2(this.item.Physics.Location.X, BlockSpriteFactory.Instance.VerticalOffset);
            }
        }
    }
}