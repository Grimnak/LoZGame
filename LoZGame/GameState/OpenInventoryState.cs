namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class OpenInventoryState : IGameState
    {
        private ISprite sprite;
        private int transitionSpeed;
        private int lockout;
        private Vector2 position;
        private int screenWidth = LoZGame.Instance.GraphicsDevice.Viewport.Width;
        private int screenHeight = LoZGame.Instance.GraphicsDevice.Viewport.Height;

        public OpenInventoryState()
        {
            this.lockout = 0;
            this.transitionSpeed = 5;
            this.sprite = CreateCorrectLevelSprite();
            this.position = new Vector2(0, -screenHeight);
        }

        /// <inheritdoc></inheritdoc>
        public void Death()
        {
            // Can't die while accessing inventory.
        }

        /// <inheritdoc></inheritdoc>
        public void OpenInventory()
        {
            // Can't transition to a state you're already in.
        }

        /// <inheritdoc></inheritdoc>
        public void CloseInventory()
        {
            if (lockout > screenHeight)
            {
                LoZGame.Instance.GameState = new CloseInventoryState();
            }
        }

        /// <inheritdoc></inheritdoc>
        public void PlayGame()
        {
            // Can't immediately play game with inventory opened; must close inventory first.
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
            if (this.lockout <= screenHeight)
            {
                this.position.Y += transitionSpeed;
            }
        }

        /// <inheritdoc></inheritdoc>
        public void Draw()
        {
            if (LoZGame.Instance.Dungeon.CurrentRoomX != 1 || LoZGame.Instance.Dungeon.CurrentRoomY != 1)
            {
                if (LoZGame.Instance.Dungeon.CurrentRoomX != 0 || LoZGame.Instance.Dungeon.CurrentRoomY != 2)
                {
                    LoZGame.Instance.SpriteBatch.Draw(LoZGame.Instance.Background, new Rectangle(0, 0, screenWidth, screenHeight), new Rectangle(0, 0, 236, 160), LoZGame.Instance.DungeonTint, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0f);
                }
                else
                {
                    LoZGame.Instance.SpriteBatch.Draw(LoZGame.Instance.BackgroundHole, new Rectangle(0, 0, screenWidth, screenHeight), new Rectangle(0, 0, 236, 160), LoZGame.Instance.DungeonTint, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0f);
                }

            }

            foreach (IPlayer player in LoZGame.Instance.Players)
            {
                player.Draw();
            }

            LoZGame.Instance.GameObjects.Draw();
            this.sprite.Draw(position, LoZGame.Instance.DungeonTint, 1.0f);
        }

        private ISprite CreateCorrectLevelSprite()
        {
            return ScreenSpriteFactory.Instance.CreateInventory();
        }
    }
}