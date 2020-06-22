namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class ItemEssentials
    {
        private int bobDelay = LoZGame.Instance.UpdateSpeed / 2;
        private int frameDelay = -1;
        private int lifeTime = 0;
        private int pickUpItemTime = -1;
        private bool expired = false;
        private ISprite sprite = ItemSpriteFactory.Instance.Arrow();

        public ItemType ItemName { get; }

        public int LifeTime { get { return lifeTime; } set { lifeTime = value; } }

        public int PickUpItemTime { get { return pickUpItemTime; } set { pickUpItemTime = value; } }

        public int FrameDelay { get { return frameDelay; } set { frameDelay = value; } }

        public bool Expired { get { return expired; } set { expired = value; } }

        public ISprite Sprite { get { return sprite; } set { sprite = value; } }

        public Physics Physics { get; set; }

        public ItemCollisionHandler itemCollisionHandler { get; set; }

        public void StartBob()
        {
            Physics.MovementVelocity = new Vector2(0, -1);
            Physics.MovementAcceleration = new Vector2(0, 1.0f / (bobDelay / 2));
        }

        public void ReverseBob()
        {
            Physics.MovementAcceleration *= -1;
        }

        public virtual void Update()
        {
            LifeTime++;
            Physics.Move();
            Physics.Accelerate();
            if (lifeTime % bobDelay == 0)
            {
                ReverseBob();
            }
            if (frameDelay != -1 && lifeTime % frameDelay == 0)
            {
                Sprite.Update();
            }
        }

        public virtual void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                if (this is PurchaseRupee)
                {
                    if (LoZGame.Instance.Players[0].Inventory.Rupees >= 50 && LoZGame.Instance.Players[0].PurchaseLockout <= 0)
                    {
                        itemCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
                    }
                }
                else
                {
                    itemCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
                }
            }
        }

        public virtual void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            itemCollisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

        public virtual void Draw(Color spriteTint)
        {
            Sprite.Draw(Physics.Location, spriteTint, Physics.Depth);
        }

    }
}
