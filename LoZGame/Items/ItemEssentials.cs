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

        public int LifeTime { get { return lifeTime; } set { this.lifeTime = value; } }

        public int PickUpItemTime { get { return pickUpItemTime; } set { this.pickUpItemTime = value; } }

        public int FrameDelay { get { return frameDelay; } set { this.frameDelay = value; } }

        public bool Expired { get { return expired; } set { this.expired = value; } }

        public ISprite Sprite { get { return sprite; } set { this.sprite = value; } }

        public Physics Physics { get; set; }

        public ItemCollisionHandler itemCollisionHandler { get; set; }

        public void StartBob()
        {
            this.Physics.MovementVelocity = new Vector2(0, 0);
            this.Physics.MovementAcceleration = new Vector2(0, 1 / (bobDelay * 2));
        }

        public void ReverseBob()
        {
            this.Physics.MovementAcceleration *= -1;
        }

        public virtual void Update()
        {
            LifeTime++;
            this.Physics.Move();
            this.Physics.Accelerate();
            if (this.lifeTime % bobDelay == 0)
            {
                this.ReverseBob();
            }
            if (frameDelay != -1 && this.lifeTime % this.frameDelay == 0)
            {
                this.Sprite.Update();
            }
        }

        public virtual void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                itemCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
        }

        public virtual void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            itemCollisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

        public virtual void Draw(Color spriteTint)
        {
            this.Sprite.Draw(this.Physics.Location, spriteTint, this.Physics.Depth);
        }

    }
}
