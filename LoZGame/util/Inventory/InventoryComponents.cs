namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Contains all of the necessary methods for updating and drawing the inventory during gameplay.
    /// </summary>
    public partial class InventoryComponents
    {
        private static readonly InventoryComponents InstanceValue = new InventoryComponents();

        public static InventoryComponents Instance => InstanceValue;

        private InventoryComponents()
        {
            inventoryBackgroundSprite = CreateInventorySprite();
            inventoryBackgroundPosition = new Vector2(0, -(LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset));
        }

        /// <summary>
        /// Draws all of the inventory components above the gameplay area, including the background, hearts, maps, and weapons.
        /// </summary>
        public void DrawInventoryElements()
        {
            inventoryBackgroundSprite.Draw(inventoryBackgroundPosition, Color.White, GameData.Instance.InventoryConstants.InvendtoryBackgroundDepth);
            DrawHearts();
            DrawTextIndicators();
            DrawMaps();
            DrawMapCompassIndicators();
            DrawSelectionItems();
            DrawEquippedItems();
            DrawEquippedItems();
        }

        /// <summary>
        /// If the game is reset while the inventory is in use, this will reset the position back to its default position.
        /// </summary>
        public void Reset()
        {
            inventoryBackgroundPosition = new Vector2(0, -(LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset));
        }

        /// <summary>
        /// Draws the hearts in the HUD in rows of eight hearts each.
        /// </summary>
        public void DrawHearts()
        {
            Vector2 firstHeartPosition = inventoryBackgroundPosition + heartOffset;
            int heartCount = LoZGame.Instance.Link.Health.CurrentHealth / GameData.Instance.InventoryConstants.HealthPerHeart;
            int partialCount = LoZGame.Instance.Link.Health.CurrentHealth % GameData.Instance.InventoryConstants.HealthPerHeart;
            int rowCounter = 0;
            int columnCounter = 0;

            for (int i = heartCount; i > 0; i--)
            {
                ISprite heartSlot = CreateFullHeartSprite();
                Vector2 heartPosition = new Vector2(firstHeartPosition.X + (InventorySpriteFactory.Instance.HeartSize.X * columnCounter), firstHeartPosition.Y + (InventorySpriteFactory.Instance.HeartSize.Y * rowCounter));

                heartSlot.Draw(heartPosition, Color.White, 1.0f);
                columnCounter++;
                if (columnCounter >= GameData.Instance.InventoryConstants.HeartColumns)
                {
                    columnCounter = 0;
                    rowCounter++;
                }
            }

            if (partialCount != 0)
            {
                ISprite heartSlot = CreatePartialHeartSprite(partialCount);
                Vector2 heartPosition = new Vector2(firstHeartPosition.X + (InventorySpriteFactory.Instance.HeartSize.X * columnCounter), firstHeartPosition.Y + (InventorySpriteFactory.Instance.HeartSize.Y * rowCounter));

                heartSlot.Draw(heartPosition, Color.White, 1.0f);
                columnCounter++;
                if (columnCounter >= GameData.Instance.InventoryConstants.HeartColumns)
                {
                    columnCounter = 0;
                    rowCounter++;
                }
            }

            int missingCount = (LoZGame.Instance.Link.Health.MaxHealth - LoZGame.Instance.Link.Health.CurrentHealth) / GameData.Instance.InventoryConstants.HealthPerHeart;
            for (int i = missingCount; i > 0; i--)
            {
                ISprite heartSlot = CreateEmptyHeartSprite();
                Vector2 heartPosition = new Vector2(firstHeartPosition.X + (InventorySpriteFactory.Instance.HeartSize.X * columnCounter), firstHeartPosition.Y + (InventorySpriteFactory.Instance.HeartSize.Y * rowCounter));

                heartSlot.Draw(heartPosition, Color.White, 1.0f);
                columnCounter++;
                if (columnCounter >= GameData.Instance.InventoryConstants.HeartColumns)
                {
                    columnCounter = 0;
                    rowCounter++;
                }
            }
        }

        /// <summary>
        /// Draws the current rupee, key, and bomb count in the HUD.
        /// </summary>
        private void DrawTextIndicators()
        {
            // Item counts.
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, GameData.Instance.InventoryConstants.ItemCtStr + LoZGame.Instance.Players[0].Inventory.Rupees.ToString(), inventoryBackgroundPosition + rupeeCountOffset, Color.White, 0.0f, new Vector2(0, 0), 0.90f, SpriteEffects.None, 1f);
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, GameData.Instance.InventoryConstants.ItemCtStr + LoZGame.Instance.Players[0].Inventory.Keys.ToString(), inventoryBackgroundPosition + keyCountOffset, Color.White, 0.0f, new Vector2(0, 0), 0.90f, SpriteEffects.None, 1f);
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, GameData.Instance.InventoryConstants.ItemCtStr + LoZGame.Instance.Players[0].Inventory.Bombs.ToString() + "/" + LoZGame.Instance.Players[0].Inventory.MaxBombs, inventoryBackgroundPosition + bombCountOffset, Color.White, 0.0f, new Vector2(0, 0), 0.90f, SpriteEffects.None, 1f);

            // Level indicator.
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, GameData.Instance.InventoryConstants.LevelStr + LoZGame.Instance.Dungeon.DungeonNumber.ToString(), inventoryBackgroundPosition + levelCountOffset, Color.White, 0.0f, new Vector2(0, 0), 1.00f, SpriteEffects.None, 1f);
        }

        /// <summary>
        /// Draws the map and compass indicator if collected by the player.
        /// </summary>
        private void DrawMapCompassIndicators()
        {
            ISprite mapSprite = CreateMapSprite();
            ISprite compassSprite = CreateCompassSprite();

            if (LoZGame.Instance.Players[0].Inventory.HasMap)
            {
                mapSprite.Draw(inventoryBackgroundPosition + mapIndicatorOffset, Color.White, 1.0f);
            }

            if (LoZGame.Instance.Players[0].Inventory.HasCompass)
            {
                compassSprite.Draw(inventoryBackgroundPosition + compassIndicatorOffset, Color.White, 1.0f);
            }
        }

        /// <summary>
        /// Draws the currently equipped weapon and item in the HUD.
        /// </summary>
        private void DrawEquippedItems()
        {
            ISprite equippedWeaponSprite = CreatePrimaryWeaponSprite();
            ISprite selectedItem;

            switch (LoZGame.Instance.Players[0].Inventory.SelectedItem)
            {
                case InventoryManager.ItemType.Bomb:
                    selectedItem = CreateBombSprite();
                    break;

                case InventoryManager.ItemType.Flute:
                    selectedItem = CreateFluteSprite();
                    break;

                case InventoryManager.ItemType.Boomerang:
                    selectedItem = CreateBoomerangSprite();
                    break;

                case InventoryManager.ItemType.Arrow:
                    selectedItem = CreateArrowSprite();
                    break;

                case InventoryManager.ItemType.Candle:
                    selectedItem = CreateCandleSprite();
                    break;

                case InventoryManager.ItemType.Potion:
                    selectedItem = CreateHealthPotionSprite();
                    break;

                case InventoryManager.ItemType.Rod:
                    selectedItem = CreateRodSprite();
                    break;

                default:
                    selectedItem = CreateBombSprite();
                    break;
            }

            selectedItem.Draw(inventoryBackgroundPosition + selectedItemOffset, Color.White, 1.0f);

            // Only show the equipped items while playing the game (as per original game behavior).
            if (!(LoZGame.Instance.GameState is OpenInventoryState || LoZGame.Instance.GameState is CloseInventoryState))
            {
                selectedItem.Draw(inventoryBackgroundPosition + secondaryEquippedOffset, Color.White, 1.0f);
                equippedWeaponSprite.Draw(inventoryBackgroundPosition + primaryEquippedOffset, Color.White, 1.0f);
            }
        }

        /// <summary>
        /// Draws the selection items if collected by the player.
        /// </summary>
        private void DrawSelectionItems()
        {
            ISprite itemSelector = CreateItemSelector();
            Vector2 firstItemPosition = inventoryBackgroundPosition + itemSelectionOffset;

            int rowCounter = 0;
            int columnCounter = 0;

            for (int position = 0; position < GameData.Instance.InventoryConstants.InventorySelectionItems; position++)
            {
                ISprite selectionItem = CreateBombSprite();
                Vector2 itemPosition = new Vector2(firstItemPosition.X + (InventorySpriteFactory.Instance.SelectionBoxSize.X * columnCounter), firstItemPosition.Y + (InventorySpriteFactory.Instance.SelectionBoxSize.Y * rowCounter));
                Vector2 itemSelectorPosition = new Vector2((firstItemPosition.X - GameData.Instance.InventoryConstants.ItemSelectorOffset) + (InventorySpriteFactory.Instance.SelectionBoxSize.X * columnCounter), (firstItemPosition.Y - GameData.Instance.InventoryConstants.ItemSelectorOffset) + (InventorySpriteFactory.Instance.SelectionBoxSize.Y * rowCounter));

                if (LoZGame.Instance.Players[0].Inventory.SelectionX == columnCounter && LoZGame.Instance.Players[0].Inventory.SelectionY == rowCounter)
                {
                    itemSelector.Draw(itemSelectorPosition, Color.White, 1.0f);
                }

                DetermineItemToDraw(selectionItem, itemPosition, position);

                columnCounter++;
                if (columnCounter >= GameData.Instance.InventoryConstants.InventoryColumns)
                {
                    columnCounter = 0;
                    rowCounter++;
                }
            }
        }

        /// <summary>
        /// Draws inventory selection items into the appropriate boxes if the player has them.
        /// </summary>
        /// <param name="selectionItem">The sprite to draw.</param>
        /// <param name="itemPosition">The location where the sprite should be drawn.</param>
        /// <param name="counter">The position in the inventory's selection box array.</param>
        private void DetermineItemToDraw(ISprite selectionItem, Vector2 itemPosition, int counter)
        {
            switch (counter)
            {
                case 0:
                    {
                        selectionItem = CreateBombSprite();
                        if (LoZGame.Instance.Players[0].Inventory.Bombs > 0)
                        {
                            selectionItem.Draw(itemPosition, Color.White, 1.0f);
                        }
                        break;
                    }
                case 1:
                    selectionItem = CreateBoomerangSprite();
                    if (LoZGame.Instance.Players[0].Inventory.HasBoomerang)
                    {
                        selectionItem.Draw(itemPosition, Color.White, 1.0f);
                    }
                    break;

                case 2:
                    selectionItem = CreateArrowSprite();
                    if (LoZGame.Instance.Players[0].Inventory.HasBow && (LoZGame.Instance.Players[0].Inventory.HasArrow || LoZGame.Instance.Players[0].Inventory.HasSilverArrow) && LoZGame.Instance.Players[0].Inventory.Rupees > 0)
                    {
                        selectionItem.Draw(itemPosition, Color.White, 1.0f);
                    }
                    break;

                case 3:
                    selectionItem = CreateCandleSprite();
                    if (LoZGame.Instance.Players[0].Inventory.HasBlueFlame || LoZGame.Instance.Players[0].Inventory.HasRedFlame)
                    {
                        selectionItem.Draw(itemPosition, Color.White, 1.0f);
                    }
                    break;

                case 4:
                    selectionItem = CreateHealthPotionSprite();
                    if (LoZGame.Instance.Players[0].Inventory.Potions > 0)
                    {
                        selectionItem.Draw(itemPosition, Color.White, 1.0f);
                    }
                    break;

                case 5:
                    selectionItem = CreateRodSprite();
                    if (LoZGame.Instance.Players[0].Inventory.HasRod)
                    {
                        selectionItem.Draw(itemPosition, Color.White, 1.0f);
                    }
                    break;

                case 6:
                    selectionItem = CreateEmptySprite();
                    break;

                case 7:
                    selectionItem = CreateFluteSprite();
                    if (LoZGame.Instance.Players[0].Inventory.HasFlute)
                    {
                        selectionItem.Draw(itemPosition, Color.White, 1.0f);
                    }
                    break;

                default:
                    selectionItem = CreateEmptySprite();
                    selectionItem.Draw(itemPosition, Color.White, 1.0f);
                    break;
            }
        }

        /// <summary>
        /// Draws the maps above the inventory background.
        /// </summary>
        private void DrawMaps()
        {
            if (!(LoZGame.Instance.Dungeon is null))
            {
                Vector2 inventoryFirstRoomPosition = inventoryBackgroundPosition + inventoryMapOffset;
                Vector2 miniMapFirstRoomPosition = InventoryBackgroundPosition + miniMapOffset;
                LoZGame.Instance.Dungeon.MiniMap.Draw(inventoryFirstRoomPosition, miniMapFirstRoomPosition);
            }
        }

        /// <summary>
        /// Draws the correct dungeon background text while the inventory is transitioning in or out.
        /// </summary>
        public void DrawText()
        {
            switch (LoZGame.Instance.Dungeon.DungeonNumber)
            {
                case 1:
                    if (LoZGame.Instance.Dungeon.CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon1TxtRoomX && LoZGame.Instance.Dungeon.CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon1TxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, LoZGame.Instance.Dungeon.CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon1TxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    break;
                case 2:
                    if (LoZGame.Instance.Dungeon.CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon2TxtRoomX && LoZGame.Instance.Dungeon.CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon2TxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, LoZGame.Instance.Dungeon.CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon2TxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    break;
                case 3:
                    if (LoZGame.Instance.Dungeon.CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon3TxtRoomX && LoZGame.Instance.Dungeon.CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon3TxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, LoZGame.Instance.Dungeon.CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon3TxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    break;
                case 4:
                    if (LoZGame.Instance.Dungeon.CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon4TxtRoomX && LoZGame.Instance.Dungeon.CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon4TxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, LoZGame.Instance.Dungeon.CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon4TxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    break;
                case 5:
                    if (LoZGame.Instance.Dungeon.CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon5FluteTxtRoomX && LoZGame.Instance.Dungeon.CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon5FluteTxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, LoZGame.Instance.Dungeon.CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon5FluteTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    else if (LoZGame.Instance.Dungeon.CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon5BombTxtRoomX && LoZGame.Instance.Dungeon.CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon5BombTxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, LoZGame.Instance.Dungeon.CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon5BombTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    else if (LoZGame.Instance.Dungeon.CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon5ArrowTxtRoomX && LoZGame.Instance.Dungeon.CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon5ArrowTxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, LoZGame.Instance.Dungeon.CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon5ArrowTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    break;
                case 6:
                    if (LoZGame.Instance.Dungeon.CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon6BossHintTxtRoomX && LoZGame.Instance.Dungeon.CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon6BossHintTxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, LoZGame.Instance.Dungeon.CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon6BossHintTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    else if (LoZGame.Instance.Dungeon.CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon6MagicRodTxtRoomX && LoZGame.Instance.Dungeon.CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon6MagicRodTxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, LoZGame.Instance.Dungeon.CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon6MagicRodTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}