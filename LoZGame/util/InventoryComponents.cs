﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Contains all of the necessary components to construct the inventory during gameplay and draw it appropriately.
    /// </summary>
    public class InventoryComponents
    {
        private static readonly InventoryComponents InstanceValue = new InventoryComponents();

        public static InventoryComponents Instance => InstanceValue;

        private ISprite inventoryBackgroundSprite;
        private Vector2 inventoryBackgroundPosition;
        private Vector2 firstHeartPosition;
        private Vector2 firstRoomPosition;
        private Vector2 rupeeCountPosition;
        private Vector2 keyCountPosition;
        private Vector2 bombCountPosition;

        private Vector2 mapRoomOffset = new Vector2(320, 263);
        private Vector2 heartOffset = new Vector2(550, 105 + (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset));
        private Vector2 rupeeCountOffset = new Vector2(305, 58 + (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset));
        private Vector2 keyCountOffset = new Vector2(305, 101 + (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset));
        private Vector2 bombCountOffset = new Vector2(305, 125 + (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset));

        public Vector2 InventoryBackgroundPosition { get { return inventoryBackgroundPosition; } set { inventoryBackgroundPosition = value; } }

        public float InventoryBackgroundPositionY { get { return inventoryBackgroundPosition.Y; } set { inventoryBackgroundPosition.Y = value; } }

        private InventoryComponents()
        {
            inventoryBackgroundSprite = CreateInventorySprite();
            inventoryBackgroundPosition = new Vector2(0, -(LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset));
            firstHeartPosition = inventoryBackgroundPosition + heartOffset;
            firstRoomPosition = inventoryBackgroundPosition + mapRoomOffset;
            rupeeCountPosition = inventoryBackgroundPosition + rupeeCountOffset;
            keyCountPosition = inventoryBackgroundPosition + keyCountOffset;
            bombCountPosition = inventoryBackgroundPosition + bombCountOffset;
        }

        /// <summary>
        /// Draws all of the inventory components above the gameplay area, including the background, hearts, maps, and weapons.
        /// </summary>
        public void DrawInventoryElements()
        {
            this.inventoryBackgroundSprite.Draw(this.inventoryBackgroundPosition, LoZGame.Instance.DefaultTint, 0.99f);
            this.DrawHearts();
            this.DrawItemCounts();
            this.DrawMap();
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
            this.firstHeartPosition = InventoryBackgroundPosition + heartOffset;
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
        private void DrawItemCounts()
        {
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, "x" + LoZGame.Instance.Players[0].Inventory.Rupees.ToString(), inventoryBackgroundPosition + rupeeCountOffset, Color.White, 0.0f, new Vector2(0, 0), 0.90f, SpriteEffects.None, 1f);
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, "x" + LoZGame.Instance.Players[0].Inventory.Keys.ToString(), inventoryBackgroundPosition + keyCountOffset, Color.White, 0.0f, new Vector2(0, 0), 0.90f, SpriteEffects.None, 1f);
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, "x" + LoZGame.Instance.Players[0].Inventory.Bombs.ToString(), inventoryBackgroundPosition + bombCountOffset, Color.White, 0.0f, new Vector2(0, 0), 0.90f, SpriteEffects.None, 1f);
        }

        /// <summary>
        /// Draws the map above the inventory background.
        /// </summary>
        private void DrawMap()
        {
            if (!(LoZGame.Instance.Dungeon is null))
            {
                this.firstRoomPosition = inventoryBackgroundPosition + mapRoomOffset;
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