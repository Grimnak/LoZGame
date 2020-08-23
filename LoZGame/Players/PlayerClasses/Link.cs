namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;

    public partial class Link : IPlayer
    {
        private PlayerCollisionHandler linkCollisionHandler;

        public Link(Vector2 location)
        {
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.PlayerConstants.Mass;
            Health = new HealthManager(GameData.Instance.PlayerConstants.StartingHealth);
            Inventory = new InventoryManager(this);
            BackupInventory = new InventoryManager(Inventory);
            linkCollisionHandler = new PlayerCollisionHandler(this);
            CurrentColor = LinkColor.Green;
            Physics.CurrentDirection = Physics.Direction.North;
            CurrentTint = Color.White;
            MoveSpeed = GameData.Instance.PlayerConstants.PlayerSpeed;
            DamageTimer = 0;
            DisarmedTimer = 0;
            PurchaseLockout = 0;
            State = new IdleState(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y - 8, LinkSpriteFactory.LinkWidth, LinkSpriteFactory.LinkHeight - 8);
            Physics.BoundsOffset = new Vector2(0, -8);
            Physics.SetLocation();
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IEnemy && !(State is PickupItemState))
            {
                linkCollisionHandler.OnCollisionResponse((IEnemy)otherCollider, collisionSide);
            }
            else if (otherCollider is IProjectile && !(State is PickupItemState))
            {
                linkCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
            else if (otherCollider is IBlock)
            {
                linkCollisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
            else if (otherCollider is IDoor)
            {
                linkCollisionHandler.OnCollisionResponse((IDoor)otherCollider, collisionSide);
            }
            else if (otherCollider is IItem && !(State is PickupItemState))
            {
                if (otherCollider is PurchaseRupee)
                {
                    if (Inventory.Rupees >= 50 && PurchaseLockout <= 0)
                    {
                        linkCollisionHandler.OnCollisionResponse((IItem)otherCollider, collisionSide);
                    }
                }
                else
                {
                    linkCollisionHandler.OnCollisionResponse((IItem)otherCollider, collisionSide);
                }
            }

        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            linkCollisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }
    }
}
