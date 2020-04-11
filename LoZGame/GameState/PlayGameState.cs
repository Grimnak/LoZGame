namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class PlayGameState : IGameState
    {
        private ISprite inventorySprite;
        private Vector2 position;

        public ISprite InventorySprite { get { return inventorySprite; } set { inventorySprite = value; } }

        public PlayGameState()
        {
            this.inventorySprite = CreateInventorySprite();
            this.position = new Vector2(0, -(LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset));

        }

        /// <inheritdoc></inheritdoc>
        public void Death()
        {
            LoZGame.Instance.GameState = new DeathState();
        }

        /// <inheritdoc></inheritdoc>
        public void OpenInventory()
        {
            LoZGame.Instance.GameState = new OpenInventoryState();
        }

        /// <inheritdoc></inheritdoc>
        public void CloseInventory()
        {
            // Can't close inventory when it's not open.
        }

        /// <inheritdoc></inheritdoc>
        public void PlayGame()
        {
            // Can't transition into a state you are already in.
        }

        /// <inheritdoc></inheritdoc>
        public void TitleScreen()
        {
            LoZGame.Instance.GameState = new TitleScreenState();
        }

        /// <inheritdoc></inheritdoc>
        public void TransitionRoom(string direction)
        {
            LoZGame.Instance.GameState = new TransitionRoomState(direction);
        }

        /// <inheritdoc></inheritdoc>
        public void WinGame()
        {
            LoZGame.Instance.GameState = new WinGameState();
        }

        /// <inheritdoc></inheritdoc>
        public void Update()
        {
            foreach (IPlayer player in LoZGame.Instance.Players)
            {
                player.Update();
            }
            LoZGame.Instance.GameObjects.Update();
            LoZGame.Instance.CollisionDetector.Update(LoZGame.Instance.Players.AsReadOnly(), LoZGame.Instance.GameObjects.Enemies.EnemyList.AsReadOnly(), LoZGame.Instance.GameObjects.Blocks.BlockList.AsReadOnly(), LoZGame.Instance.GameObjects.Doors.DoorList.AsReadOnly(), LoZGame.Instance.GameObjects.Items.ItemList.AsReadOnly(), LoZGame.Instance.GameObjects.Entities.PlayerProjectiles.AsReadOnly(), LoZGame.Instance.GameObjects.Entities.EnemyProjectiles.AsReadOnly());

        }

        /// <inheritdoc></inheritdoc>
        public void Draw()
        {
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            this.DrawCorrectBackground();

            LoZGame.Instance.GameObjects.Draw();

            this.DrawText();

            foreach (IPlayer player in LoZGame.Instance.Players)
            {
                player.Draw();
            }
            LoZGame.Instance.SpriteBatch.End();

            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            this.inventorySprite.Draw(position, LoZGame.Instance.DefaultTint, 1.0f);
            //LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, "Health: " + LoZGame.Instance.Link.Health.CurrentHealth.ToString() + " | Bombs: " + LoZGame.Instance.Link.Inventory.Bombs.ToString() + " | Rupees: " + LoZGame.Instance.Link.Inventory.Rupees.ToString(), new Vector2(0,0), Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 1.0f);
            LoZGame.Instance.SpriteBatch.End();

            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            LoZGame.Instance.Dungeon.MiniMap.Draw();
            LoZGame.Instance.SpriteBatch.End();
        }

        private void DrawCorrectBackground()
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

        private void DrawText()
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

        private ISprite CreateInventorySprite()
        {
            return ScreenSpriteFactory.Instance.CreateInventory();
        }
    }
}