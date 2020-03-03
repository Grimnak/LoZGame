namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    internal class Bomb : IItem
    {
        IItemSprite sprite;

        public Physics Physics
        {
            get { return this.sprite.Physics; }
            set { this.sprite.Physics = value; }
        }

        public Rectangle Bounds
        {
            get { return this.sprite.Bounds; }
            set { this.sprite.Bounds = value; }
        }

        public Bomb(Vector2 loc)
        {
            this.sprite = ItemSpriteFactory.Instance.Bomb(loc, ItemSpriteFactory.Instance.Scale);
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            this.sprite.OnCollisionResponse(otherCollider, collisionSide);
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw();
        }
    }
}