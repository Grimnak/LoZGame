namespace LoZClone
{
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
            this.inventoryBackgroundSprite.Draw(this.inventoryBackgroundPosition, LoZGame.Instance.DefaultTint, 0.99f);
            this.DrawHearts();
            this.DrawTextIndicators();
            this.DrawMap();
            this.DrawMapCompassIndicators();
        }

        /// <summary>
        /// If the game is reset while the inventory is in use, this will reset the position back to its default position.
        /// </summary>
        public void Reset()
        {
            this.inventoryBackgroundPosition = new Vector2(0, -(LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset));
        }

        /// <summary>
        /// Draws the hearts in the HUD in rows of eight hearts each.
        /// </summary>
        public void DrawHearts()
        {
            Vector2 firstHeartPosition = this.inventoryBackgroundPosition + heartOffset;
            int heartCount = LoZGame.Instance.Link.Health.CurrentHealth / 4;
            int partialCount = LoZGame.Instance.Link.Health.CurrentHealth % 4;
            int rowCounter = 0;
            int columnCounter = 0;

            for (int i = heartCount; i > 0; i--)
            {
                ISprite heartSlot = CreateFullHeartSprite();
                Vector2 heartPosition = new Vector2(firstHeartPosition.X + (InventorySpriteFactory.Instance.HeartSize.X * columnCounter), firstHeartPosition.Y + (InventorySpriteFactory.Instance.HeartSize.Y * rowCounter));

                heartSlot.Draw(heartPosition, LoZGame.Instance.DefaultTint, 1.0f);
                columnCounter++;
                if (columnCounter >= 8)
                {
                    columnCounter = 0;
                    rowCounter++;
                }
            }

            if (partialCount != 0)
            {
                ISprite heartSlot = CreatePartialHeartSprite(partialCount);
                Vector2 heartPosition = new Vector2(firstHeartPosition.X + (InventorySpriteFactory.Instance.HeartSize.X * columnCounter), firstHeartPosition.Y + (InventorySpriteFactory.Instance.HeartSize.Y * rowCounter));

                heartSlot.Draw(heartPosition, LoZGame.Instance.DefaultTint, 1.0f);
                columnCounter++;
                if (columnCounter >= 8)
                {
                    columnCounter = 0;
                    rowCounter++;
                }
            }

            int missingCount = (LoZGame.Instance.Link.Health.MaxHealth - LoZGame.Instance.Link.Health.CurrentHealth) / 4;
            for (int i = missingCount; i > 0; i--)
            {
                ISprite heartSlot = CreateEmptyHeartSprite();
                Vector2 heartPosition = new Vector2(firstHeartPosition.X + (InventorySpriteFactory.Instance.HeartSize.X * columnCounter), firstHeartPosition.Y + (InventorySpriteFactory.Instance.HeartSize.Y * rowCounter));

                heartSlot.Draw(heartPosition, LoZGame.Instance.DefaultTint, 1.0f);
                columnCounter++;
                if (columnCounter >= 8)
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
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, "x" + LoZGame.Instance.Players[0].Inventory.Rupees.ToString(), inventoryBackgroundPosition + rupeeCountOffset, Color.White, 0.0f, new Vector2(0, 0), 0.90f, SpriteEffects.None, 1f);
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, "x" + LoZGame.Instance.Players[0].Inventory.Keys.ToString(), inventoryBackgroundPosition + keyCountOffset, Color.White, 0.0f, new Vector2(0, 0), 0.90f, SpriteEffects.None, 1f);
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, "x" + LoZGame.Instance.Players[0].Inventory.Bombs.ToString(), inventoryBackgroundPosition + bombCountOffset, Color.White, 0.0f, new Vector2(0, 0), 0.90f, SpriteEffects.None, 1f);

            // Level indicator.
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, "L E V E L - " + LoZGame.Instance.Dungeon.DungeonNumber.ToString(), inventoryBackgroundPosition + levelCountOffset, Color.White, 0.0f, new Vector2(0, 0), 1.00f, SpriteEffects.None, 1f);
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
                mapSprite.Draw(inventoryBackgroundPosition + mapIndicatorOffset, LoZGame.Instance.DefaultTint, 1.0f);
            }

            if (LoZGame.Instance.Players[0].Inventory.HasCompass)
            {
                compassSprite.Draw(inventoryBackgroundPosition + compassIndicatorOffset, LoZGame.Instance.DefaultTint, 1.0f);
            }
        }

        private void DrawSelectionItems()
        {
            Vector2 firstItemPosition = this.inventoryBackgroundPosition + selectionOffset;
            int rowCounter = 0;
            int columnCounter = 0;

            for (int position = 0; position < 8; position++)
            {
                ISprite selectionItem = CreateBombSprite();
                Vector2 itemPosition = new Vector2(firstItemPosition.X + (InventorySpriteFactory.Instance.SelectionBoxSize.X * columnCounter), firstItemPosition.Y + (InventorySpriteFactory.Instance.SelectionBoxSize.Y * rowCounter));

                this.DetermineItemToDraw(selectionItem, itemPosition, position);

                columnCounter++;
                if (columnCounter >= 4)
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
                case 1:
                    {
                        selectionItem = CreateBombSprite();
                        if (LoZGame.Instance.Players[0].Inventory.Bombs > 0)
                        {
                            selectionItem.Draw(itemPosition, LoZGame.Instance.DefaultTint, 1.0f);
                        }
                        break;
                    }
                case 2:
                    {
                        selectionItem = CreateBoomerangSprite();
                        if (LoZGame.Instance.Players[0].Inventory.HasBoomerang)
                        {
                            selectionItem.Draw(itemPosition, LoZGame.Instance.DefaultTint, 1.0f);
                        }
                        break;
                    }
                case 3:
                    {
                        selectionItem = CreateArrowSprite();
                        if (LoZGame.Instance.Players[0].Inventory.HasBow)
                        {
                            selectionItem.Draw(itemPosition, LoZGame.Instance.DefaultTint, 1.0f);
                        }
                        break;
                    }
                case 4:
                    {
                        selectionItem = CreateBlueCandleSprite();
                        if (LoZGame.Instance.Players[0].Inventory.HasBlueFlame)
                        {
                            selectionItem.Draw(itemPosition, LoZGame.Instance.DefaultTint, 1.0f);
                        }
                        break;
                    }
                case 5:
                    {
                        selectionItem = CreateHealthPotionSprite();
                        if (LoZGame.Instance.Players[0].Inventory.HealthPotions > 0)
                        {
                            selectionItem.Draw(itemPosition, LoZGame.Instance.DefaultTint, 1.0f);
                        }
                        break;
                    }
                case 6:
                    {
                        selectionItem = CreateMagicBoomerangSprite();
                        if (LoZGame.Instance.Players[0].Inventory.HasMagicBoomerang)
                        {
                            selectionItem.Draw(itemPosition, LoZGame.Instance.DefaultTint, 1.0f);
                        }
                        break;
                    }
                case 7:
                    {
                        selectionItem = CreateSilverArrowSprite();
                        if (LoZGame.Instance.Players[0].Inventory.HasBow && LoZGame.Instance.Players[0].Inventory.HasSilverArrow)
                        {
                            selectionItem.Draw(itemPosition, LoZGame.Instance.DefaultTint, 1.0f);
                        }
                        break;
                    }
                case 8:
                    {
                        selectionItem = CreateRedCandleSprite();
                        if (LoZGame.Instance.Players[0].Inventory.HasRedFlame)
                        {
                            selectionItem.Draw(itemPosition, LoZGame.Instance.DefaultTint, 1.0f);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Draws the map above the inventory background.
        /// </summary>
        private void DrawMap()
        {
            Vector2 firstRoomPosition = inventoryBackgroundPosition + mapRoomOffset;
            if (!(LoZGame.Instance.Dungeon is null))
            {
                firstRoomPosition = inventoryBackgroundPosition + mapRoomOffset;
                LoZGame.Instance.Dungeon.MiniMap.Draw(firstRoomPosition);
            }
        }

        /// <summary>
        /// Draws the correct dungeon background with all objects while the inventory is transitioning in or out.
        /// </summary>
        public void DrawCorrectBackground()
        {
            switch (LoZGame.Instance.Dungeon.DungeonNumber)
            {
                case 1:
                    if (LoZGame.Instance.Dungeon.CurrentRoomX != 1 || LoZGame.Instance.Dungeon.CurrentRoomY != 1)
                    {
                        if (LoZGame.Instance.Dungeon.CurrentRoomX != 0 || LoZGame.Instance.Dungeon.CurrentRoomY != 2)
                        {
                            LoZGame.Instance.SpriteBatch.Draw(LoZGame.Instance.Background, new Rectangle(0, LoZGame.Instance.InventoryOffset, LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset), new Rectangle(0, 0, 236, 160), LoZGame.Instance.DungeonTint, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0f);
                        }
                        else
                        {
                            LoZGame.Instance.SpriteBatch.Draw(LoZGame.Instance.BackgroundHole, new Rectangle(0, LoZGame.Instance.InventoryOffset, LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset), new Rectangle(0, 0, 236, 160), LoZGame.Instance.DungeonTint, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0f);
                        }

                    }
                    break;
                case 2:
                    if (LoZGame.Instance.Dungeon.CurrentRoomX != 3 || LoZGame.Instance.Dungeon.CurrentRoomY != 1)
                    {
                        LoZGame.Instance.SpriteBatch.Draw(LoZGame.Instance.Background, new Rectangle(0, LoZGame.Instance.InventoryOffset, LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset), new Rectangle(0, 0, 236, 160), LoZGame.Instance.DungeonTint, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0f);
                    }
                    else
                    {
                        LoZGame.Instance.SpriteBatch.Draw(LoZGame.Instance.BackgroundHole, new Rectangle(0, LoZGame.Instance.InventoryOffset, LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset), new Rectangle(0, 0, 236, 160), LoZGame.Instance.DungeonTint, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0f);
                    }
                    break;
                default:
                    break;
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
                    if (LoZGame.Instance.Dungeon.CurrentRoomX == 0 && LoZGame.Instance.Dungeon.CurrentRoomY == 2)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, LoZGame.Instance.Dungeon.CurrentRoom.RoomText, new Vector2(100, LoZGame.Instance.InventoryOffset + 100), Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    break;
                case 2:
                    if (LoZGame.Instance.Dungeon.CurrentRoomX == 3 && LoZGame.Instance.Dungeon.CurrentRoomY == 1)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, LoZGame.Instance.Dungeon.CurrentRoom.RoomText, new Vector2(185, LoZGame.Instance.InventoryOffset + 100), Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}