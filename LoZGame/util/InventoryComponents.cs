namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class InventoryComponents
    {
        private static readonly InventoryComponents InstanceValue = new InventoryComponents();

        public static InventoryComponents Instance => InstanceValue;

        private ISprite inventoryBackgroundSprite;
        private Vector2 inventoryBackgroundPosition;
        private Vector2 firstHeartPosition;
        private Vector2 firstRoomPosition;

        private Vector2 roomOffset = new Vector2(320, 263);
        private Vector2 heartOffset = new Vector2(550, 105 + (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset));

        public ISprite InventoryBackgroundSprite { get { return inventoryBackgroundSprite; } set { inventoryBackgroundSprite = value; } }

        public Vector2 InventoryBackgroundPosition { get { return inventoryBackgroundPosition; } set { inventoryBackgroundPosition = value; } }

        public float InventoryBackgroundPositionX { get { return inventoryBackgroundPosition.X; } set { inventoryBackgroundPosition.X = value; } }

        public float InventoryBackgroundPositionY { get { return inventoryBackgroundPosition.Y; } set { inventoryBackgroundPosition.Y = value; } }

        public Vector2 FirstHeartPosition { get { return FirstHeartPosition; } set { FirstHeartPosition = value; } }

        public float FirstHeartPositionY { get { return firstHeartPosition.Y; } set { firstHeartPosition.Y = value; } }

        private InventoryComponents()
        {
            inventoryBackgroundSprite = CreateInventorySprite();
            inventoryBackgroundPosition = new Vector2(0, -(LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset));
            firstHeartPosition = inventoryBackgroundPosition + heartOffset;
            firstRoomPosition = inventoryBackgroundPosition + roomOffset;
        }

        public void DrawInventoryElements()
        {
            this.inventoryBackgroundSprite.Draw(this.inventoryBackgroundPosition, LoZGame.Instance.DefaultTint, 0.99f);
            this.DrawHearts();
            this.DrawMap();
        }

        public void DrawHearts()
        {
            firstHeartPosition = InventoryBackgroundPosition + heartOffset;
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

        private void DrawMap()
        {
            if (!(LoZGame.Instance.Dungeon is null))
            {
                firstRoomPosition = inventoryBackgroundPosition + roomOffset;
                LoZGame.Instance.Dungeon.MiniMap.Draw(firstRoomPosition);
            }
        }

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
