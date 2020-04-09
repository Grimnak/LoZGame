namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class CloseInventoryState : IGameState
    {
        private ISprite sprite;
        private int transitionSpeed;
        private int lockout;
        private Vector2 position;

        public CloseInventoryState()
        {
            this.lockout = 0;
            this.transitionSpeed = 5;
            this.sprite = CreateCorrectLevelSprite();
            this.position = new Vector2(0, -LoZGame.Instance.InventoryOffset);
        }

        /// <inheritdoc></inheritdoc>
        public void Death()
        {
            // Can't die while accessing inventory.
        }

        /// <inheritdoc></inheritdoc>
        public void OpenInventory()
        {
            // Inventory already opened.
        }

        /// <inheritdoc></inheritdoc>
        public void CloseInventory()
        {
            // Can't transition to a state you're already in.
        }

        /// <inheritdoc></inheritdoc>
        public void PlayGame()
        {
            LoZGame.Instance.GameState = new PlayGameState();
        }

        /// <inheritdoc></inheritdoc>
        public void TitleScreen()
        {
            LoZGame.Instance.GameState = new TitleScreenState();
        }

        /// <inheritdoc></inheritdoc>
        public void TransitionRoom(string direction)
        {
            // Can't transition room while accessing inventory.
        }

        /// <inheritdoc></inheritdoc>
        public void WinGame()
        {
            // Can't win game while accessing inventory.
        }

        /// <inheritdoc></inheritdoc>
        public void Update()
        {
            this.lockout += this.transitionSpeed;
            if (this.lockout < LoZGame.Instance.ScreenHeight)
            {
                this.position.Y -= transitionSpeed;
            }
            else
            {
                LoZGame.Instance.GameState.PlayGame();
            }
        }

        /// <inheritdoc></inheritdoc>
        public void Draw()
        {
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            this.DrawCorrectBackground();

            foreach (IPlayer player in LoZGame.Instance.Players)
            {
                player.Draw();
            }

            LoZGame.Instance.GameObjects.Draw();
            this.sprite.Draw(position, LoZGame.Instance.DungeonTint, 1.0f);
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

        private ISprite CreateCorrectLevelSprite()
        {
            return ScreenSpriteFactory.Instance.CreateInventory();
        }
    }
}