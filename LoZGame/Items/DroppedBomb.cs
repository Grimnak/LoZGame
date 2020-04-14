namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    internal class DroppedBomb : ItemEssentials, IItem
    {
        private static readonly int DespawnTimer = LoZGame.Instance.UpdateSpeed * 20;
        private static readonly int SpawnTimer = LoZGame.Instance.UpdateSpeed * 1;
        
        public DroppedBomb(Vector2 loc)
        {
            this.Sprite = ItemSpriteFactory.Instance.Bomb();
            this.itemCollisionHandler = new ItemCollisionHandler(this);
            this.Physics = new Physics(loc);
            this.PickUpItemTime = -1;
            this.LifeTime = 0;
            Vector2 size = new Vector2(ItemSpriteFactory.RupeeWidth * ItemSpriteFactory.Instance.Scale, ItemSpriteFactory.RupeeHeight * ItemSpriteFactory.Instance.Scale);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)size.X, (int)size.Y);
            this.Expired = false;
            this.StartBob();
        }

        public override void Update()
        {
            base.Update();
            if (this.LifeTime >= DespawnTimer)
            {
                this.Expired = true;
            }
        }

        public override void Draw(Color spriteTint)
        {
            if ((this.LifeTime > SpawnTimer && this.LifeTime < (DespawnTimer - (4 * SpawnTimer))) || this.LifeTime % 4 < 2)
            {
                base.Draw(spriteTint);
            }
        }
    }
}