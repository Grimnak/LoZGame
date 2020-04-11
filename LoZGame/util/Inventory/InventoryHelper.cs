﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Contains all of the necessary variables and sprite creation methods necessary for creating the inventory.
    /// </summary>
    public partial class InventoryComponents
    {
        private ISprite inventoryBackgroundSprite;
        private Vector2 inventoryBackgroundPosition;

        private Vector2 mapRoomOffset = new Vector2(320, 263);
        private Vector2 heartOffset = new Vector2(550, 105 + (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset));
        private Vector2 rupeeCountOffset = new Vector2(305, 58 + (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset));
        private Vector2 keyCountOffset = new Vector2(305, 101 + (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset));
        private Vector2 bombCountOffset = new Vector2(305, 125 + (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset));
        private Vector2 levelCountOffset = new Vector2(58, 15 + (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset));

        public Vector2 InventoryBackgroundPosition { get { return inventoryBackgroundPosition; } set { inventoryBackgroundPosition = value; } }

        public float InventoryBackgroundPositionY { get { return inventoryBackgroundPosition.Y; } set { inventoryBackgroundPosition.Y = value; } }

        public ISprite CreateInventorySprite()
        {
            return InventorySpriteFactory.Instance.CreateInventoryBackground();
        }

        public ISprite CreateFullHeartSprite()
        {
            return InventorySpriteFactory.Instance.CreateFullHeart();
        }

        public ISprite CreateEmptyHeartSprite()
        {
            return InventorySpriteFactory.Instance.CreateEmptyHeart();
        }

        public ISprite CreatePartialHeartSprite(int partialCount)
        {
            if (partialCount == 3)
            {
                return InventorySpriteFactory.Instance.CreateThreeQuarterHeart();
            }
            else if (partialCount == 2)
            {
                return InventorySpriteFactory.Instance.CreateHalfHeart();
            }
            else if (partialCount == 1)
            {
                return InventorySpriteFactory.Instance.CreateQuarterHeart();
            }
            else
            {
                return InventorySpriteFactory.Instance.CreateEmptyHeart();
            }
        }
    }
}
