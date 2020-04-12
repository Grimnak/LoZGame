namespace LoZClone
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

        private Vector2 InventoryMapOffset = new Vector2(320, 263);
        private Vector2 mapIndicatorOffset = new Vector2(150, 313);
        private Vector2 compassIndicatorOffset = new Vector2(130, 420);
        private Vector2 selectionOffset = new Vector2(500, 80);
        private Vector2 miniMapOffset = new Vector2(45, 46 + LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset);
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

        public ISprite CreateMapSprite()
        {
            return InventorySpriteFactory.Instance.CreateInventoryMap();
        }

        public ISprite CreateCompassSprite()
        {
            return InventorySpriteFactory.Instance.CreateInventoryCompass();
        }

        public ISprite CreateBombSprite()
        {
            return InventorySpriteFactory.Instance.CreateInventoryBomb();
        }

        public ISprite CreateBoomerangSprite()
        {
            return InventorySpriteFactory.Instance.CreateInventoryBoomerang();
        }

        public ISprite CreateArrowSprite()
        {
            return InventorySpriteFactory.Instance.CreateInventoryArrow();
        }

        public ISprite CreateBlueCandleSprite()
        {
            return InventorySpriteFactory.Instance.CreateInventoryBlueCandle();
        }

        public ISprite CreateHealthPotionSprite()
        {
            if (LoZGame.Instance.Players[0].Inventory.BluePotions > 0)
            {
                return InventorySpriteFactory.Instance.CreateInventoryBlueHealthPotion();
            }
            else
            {
                return InventorySpriteFactory.Instance.CreateInventoryRedHealthPotion();
            }
        }

        public ISprite CreateMagicBoomerangSprite()
        {
            return InventorySpriteFactory.Instance.CreateInventoryMagicBoomerang();
        }

        public ISprite CreateSilverArrowSprite()
        {
            return InventorySpriteFactory.Instance.CreateInventorySilverArrow();
        }

        public ISprite CreateRedCandleSprite()
        {
            return InventorySpriteFactory.Instance.CreateInventoryRedCandle();
        }
    }
}