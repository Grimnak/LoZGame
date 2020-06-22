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
            if (item.PickUpItemTime == -1 && !(item is PurchaseRupee)) 
            {
                item.Expired = true;
            }

            if (item is Fairy)
            {
                SoundFactory.Instance.PlayGetItem();
                player.Health.CurrentHealth = player.Health.MaxHealth;
            }
            else if (item is DroppedHealth)
            {
                SoundFactory.Instance.PlayGetHeartOrKey();
                player.Health.GainHealth(4);
            }
            else if (item is HeartContainer)
            {
                SoundFactory.Instance.PlayGetItem();
                player.Health.MaxHealth = player.Health.MaxHealth + 4;
                player.Health.CurrentHealth = player.Health.MaxHealth;
            }
            else if (item is DroppedRupee || item is Rupee)
            {
                SoundFactory.Instance.PlayGetRupee();
                player.Inventory.GainRupees(1);
            }
            else if (item is DroppedYellowRupee || item is YellowRupee)
            {
                SoundFactory.Instance.PlayGetRupee();
                player.Inventory.GainRupees(5);
            }
            else if (item is PurchaseRupee)
            {
                SoundFactory.Instance.PlayGetItem();
                LoZGame.Instance.GameState.ConfirmPurchase();
            }
            else if (item is DroppedBomb || item is Bomb)
            {
                SoundFactory.Instance.PlayGetItem();
                player.Inventory.GainBombs();
            }
            else if (item is Key || item is MagicKey)
            {
                SoundFactory.Instance.PlayGetHeartOrKey();
            }
            else if (item is Triforce)
            {
                SoundFactory.Instance.PlayGetItem();
                SoundFactory.Instance.PlayTriforceTune();
            }
            else if (item is DroppedBluePotion)
            {
                SoundFactory.Instance.PlayGetItem();
                player.Inventory.GainRedPotion();
            }
            else if (item is DroppedRedPotion)
            {
                SoundFactory.Instance.PlayGetItem();
                player.Inventory.GainBluePotion();
            }
            else if (item is Clock)
            {
                SoundFactory.Instance.PlayGetItem();
                LoZGame.Instance.Players[0].Inventory.ClockLockout = 0;
                player.Inventory.HasClock = true;
            }
            else if (item is WhiteSword)
            {
                SoundFactory.Instance.PlayGetItem();
                player.CurrentWeapon = Link.LinkWeapon.White;
            }
            else if (item is MagicSword)
            {
                SoundFactory.Instance.PlayGetItem();
                player.CurrentWeapon = Link.LinkWeapon.Magic;
            }
            else
            {
                SoundFactory.Instance.PlayGetItem();
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
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            if (item is Fairy)
            {
                SetBounds(item.Physics, collisionSide);
                item.Physics.SetLocation();
            }
        }
    }
}