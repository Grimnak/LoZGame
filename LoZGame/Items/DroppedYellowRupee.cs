namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    internal class DroppedYellowRupee : ItemEssentials, IItem
    {
        private static readonly int DespawnTimer = LoZGame.Instance.UpdateSpeed * 20;
        private static readonly int SpawnTimer = LoZGame.Instance.UpdateSpeed * 1;

        public DroppedYellowRupee(Vector2 loc)
        {
            Sprite = ItemSpriteFactory.Instance.YellowRupee();
            FrameDelay = 5;
            itemCollisionHandler = new ItemCollisionHandler(this);
            Physics = new Physics(loc);
            PickUpItemTime = -1;
            LifeTime = 0;
            Vector2 size = new Vector2(ItemSpriteFactory.RupeeWidth * ItemSpriteFactory.Instance.Scale, ItemSpriteFactory.RupeeHeight * ItemSpriteFactory.Instance.Scale);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, (int)size.X, (int)size.Y);
            Expired = false;
            StartBob();
        }

        public override void Update()
        {
            base.Update();
            if (LifeTime >= DespawnTimer)
            {
                Expired = true;
            }
        }

        public override void Draw(Color spriteTint)
        {
            if ((LifeTime > SpawnTimer && LifeTime < (DespawnTimer - (4 * SpawnTimer))) || LifeTime % 4 < 2)
            {
                base.Draw(spriteTint);
            }
        }
    }
}