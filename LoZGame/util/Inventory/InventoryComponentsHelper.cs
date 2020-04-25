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

        private Vector2 inventoryMapOffset = new Vector2(GameData.Instance.InventoryConstants.InventoryMapOffsetX, GameData.Instance.InventoryConstants.InventoryMapOffsetY);
        private Vector2 mapIndicatorOffset = new Vector2(GameData.Instance.InventoryConstants.MapIndicatorOffsetX, GameData.Instance.InventoryConstants.MapIndicatorOffsetY);
        private Vector2 compassIndicatorOffset = new Vector2(GameData.Instance.InventoryConstants.CompassIndicatorOffsetX, GameData.Instance.InventoryConstants.CompassIndicatorOffsetY);
        private Vector2 itemSelectionOffset = new Vector2(GameData.Instance.InventoryConstants.ItemSelectorOffsetX, GameData.Instance.InventoryConstants.ItemSelectorOffsetY);
        private Vector2 selectedItemOffset = new Vector2(GameData.Instance.InventoryConstants.SelectedItemOffsetX, GameData.Instance.InventoryConstants.SelectedItemOffsetY);
        private Vector2 miniMapOffset = new Vector2(GameData.Instance.InventoryConstants.MiniMapOffsetX, GameData.Instance.InventoryConstants.MiniMapOffsetY);
        private Vector2 heartOffset = new Vector2(GameData.Instance.InventoryConstants.HeartOffsetX, GameData.Instance.InventoryConstants.HeartOffsetY);
        private Vector2 rupeeCountOffset = new Vector2(GameData.Instance.InventoryConstants.RupeeCtOffsetX, GameData.Instance.InventoryConstants.RupeeCtOffsetY);
        private Vector2 keyCountOffset = new Vector2(GameData.Instance.InventoryConstants.KeyCtOffsetX, GameData.Instance.InventoryConstants.KeyCtOffsetY);
        private Vector2 bombCountOffset = new Vector2(GameData.Instance.InventoryConstants.BombCtOffsetX, GameData.Instance.InventoryConstants.BombCtOffsetY);
        private Vector2 levelCountOffset = new Vector2(GameData.Instance.InventoryConstants.LevelCtOffsetX, GameData.Instance.InventoryConstants.LevelCtOffsetY);
        private Vector2 primaryEquippedOffset = new Vector2(GameData.Instance.InventoryConstants.PrimaryEquippedOffsetX, GameData.Instance.InventoryConstants.PrimaryEquippedOffsetY);
        private Vector2 secondaryEquippedOffset = new Vector2(GameData.Instance.InventoryConstants.SecondaryEquippedOffsetX, GameData.Instance.InventoryConstants.SecondaryEquippedOffsetY);

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
            if (partialCount == GameData.Instance.InventoryConstants.ThreeQuarterHeart)
            {
                return InventorySpriteFactory.Instance.CreateThreeQuarterHeart();
            }
            else if (partialCount == GameData.Instance.InventoryConstants.HalfHeart)
            {
                return InventorySpriteFactory.Instance.CreateHalfHeart();
            }
            else if (partialCount == GameData.Instance.InventoryConstants.QuarterHeart)
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
            if (LoZGame.Instance.Players[0].Inventory.HasMagicBoomerang)
            {
                return InventorySpriteFactory.Instance.CreateInventoryMagicBoomerang();
            }
            else
            {
                return InventorySpriteFactory.Instance.CreateInventoryBoomerang();
            }
        }

        public ISprite CreateArrowSprite()
        {
            if (LoZGame.Instance.Players[0].Inventory.HasSilverArrow)
            {
                return InventorySpriteFactory.Instance.CreateInventorySilverArrow();
            } 
            else
            {
                return InventorySpriteFactory.Instance.CreateInventoryArrow();
            }
        }

        public ISprite CreateCandleSprite()
        {
            if (LoZGame.Instance.Players[0].Inventory.HasRedFlame)
            {
                return InventorySpriteFactory.Instance.CreateInventoryRedCandle();
            }
            else
            {
                return InventorySpriteFactory.Instance.CreateInventoryBlueCandle();
            }
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

        public ISprite CreateFluteSprite()
        {
            return InventorySpriteFactory.Instance.CreateInventoryFlute();
        }

        public ISprite CreateEmptySprite()
        {
            return InventorySpriteFactory.Instance.EmptySlot();
        }

        public ISprite CreateItemSelector()
        {
            return InventorySpriteFactory.Instance.CreateInventoryItemSelector();
        }

        public ISprite CreatePrimaryWeaponSprite()
        {
            if (LoZGame.Instance.Players[0].CurrentWeapon.Equals(Link.LinkWeapon.White))
            {
                return InventorySpriteFactory.Instance.CreateInventoryWhiteSword();
            }
            else if (LoZGame.Instance.Players[0].CurrentWeapon.Equals(Link.LinkWeapon.Magic))
            {
                return InventorySpriteFactory.Instance.CreateInventoryMagicSword();
            }
            else
            {
                return InventorySpriteFactory.Instance.CreateInventoryWoodenSword();
            }
        }
    }
}