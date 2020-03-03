namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    internal class HalfHeart : IItem
    {
        private ISprite sprite;
        private ItemCollisionHandler itemCollisionHandler;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        public HalfHeart(Vector2 location)
        {
            this.itemCollisionHandler = new ItemCollisionHandler(this);
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.sprite = ItemSpriteFactory.Instance.HalfHeart(location, ItemSpriteFactory.Instance.Scale);
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}