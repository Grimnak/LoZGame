namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public class ItemCollisionHandler : CollisionInteractions
    {
        private IItem item;
        private Vector2 GrabbedOffset;

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

            if (this.item is Fairy)
            {
                SoundEffectsFactory.Instance.PlayGetItem();
                player.Health.CurrentHealth = player.Health.MaxHealth;
            }
            else if (this.item is DroppedHealth)
            {
                SoundEffectsFactory.Instance.PlayGetHeartOrKey();
                player.Health.GainHealth(4);
            }
            else if (this.item is HeartContainer)
            {
                SoundEffectsFactory.Instance.PlayGetItem();
                player.Health.MaxHealth = player.Health.MaxHealth + 4;
                player.Health.CurrentHealth = player.Health.MaxHealth;
            }
            else if (this.item is DroppedRupee)
            {
                SoundEffectsFactory.Instance.PlayGetRupee();
                player.Inventory.GainRupees(1);
            }
            else if (item is DroppedYellowRupee)
            {
                SoundEffectsFactory.Instance.PlayGetRupee();
                player.Inventory.GainRupees(5);
            }
            else if (item is DroppedBomb)
            {
                SoundEffectsFactory.Instance.PlayGetItem();
                player.Inventory.GainBombs();
            }
            else if (this.item is Key)
            {
                SoundEffectsFactory.Instance.PlayGetHeartOrKey();
            }
            else
            {
                SoundEffectsFactory.Instance.PlayGetItem();
            }
        }

        public void OnCollisionResponse(IProjectile projectile, CollisionDetection.CollisionSide collisionSide)
        {
            /*
            if (projectile is MagicBoomerangProjectile || projectile is BoomerangProjectile)
            {
                if (this.item is IDrop) { }
                if (!this.item.IsGrabbed)
                {
                    this.boomerang = projectile;
                    //this.GrabbedOffset = new Vector2((this.item.Bounds.Width - this.boomerang.Bounds.Width) / 2, (this.item.Bounds.Height - this.boomerang.Bounds.Height) / 2);
                    this.grabbed = true;
                }
                this.item.Physics.Location = new Vector2(this.boomerang.Physics.Location.X - GrabbedOffset.X, this.boomerang.Physics.Location.Y - this.GrabbedOffset.Y);
                this.item.Bounds = new Rectangle((int)this.item.Physics.Location.X, (int)this.item.Physics.Location.Y, this.item.Bounds.Width, this.item.Bounds.Height);
            }
            */
        }

        public void OnCollisionResponse(IDoor door, CollisionDetection.CollisionSide collisionSide)
        {
            if (door.State is HiddenDoorState)
            {
                door.Bombed();
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