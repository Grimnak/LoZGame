namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    internal class LifePotion : IItem
    {
        private ISprite sprite;
        private ItemCollisionHandler itemCollisionHandler;

        private readonly Texture2D Texture;      // the texture to pull frames from
        private Vector2 Size;
        private float layer;
        private int lifeTime;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public LifePotion(Vector2 loc)
        {
            this.sprite = ItemSpriteFactory.Instance.LifePotion(ItemSpriteFactory.Instance.Scale);
            this.itemCollisionHandler = new ItemCollisionHandler(this);
            this.Physics = new Physics(loc, new Vector2(0, -1), new Vector2(0, 0.1f));
            this.Size = new Vector2(ItemSpriteFactory.PotionWidth * ItemSpriteFactory.Instance.Scale, ItemSpriteFactory.PotionHeight * ItemSpriteFactory.Instance.Scale);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.lifeTime = 0;
        }

        private void UpdateLoc()
        {
            if ((int)Math.Abs(this.Physics.Velocity.X) > 0 || (int)Math.Abs(this.Physics.Velocity.Y) > 0)
            {
                this.Physics.Move();
                this.Physics.Accelerate();
            }
            else
            {
                this.Physics.StopMovement();
            }
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                itemCollisionHandler.OnCollisionResponse(collisionSide);
            }
        }

        public void ReverseBob()
        {
            //future method which will cause items to bob up and down
        }

        public void Update()
        {
            this.lifeTime++;
            if (this.lifeTime > 20)
            {
                this.lifeTime = 0;
                this.ReverseBob();
            }
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)this.Size.X, (int)this.Size.Y);
            this.UpdateLoc();
            this.sprite.Update();
        }

        public void Draw(Color spriteTint)
        {
            this.sprite.Draw(this.Physics.Location, spriteTint);
        }
    }
}