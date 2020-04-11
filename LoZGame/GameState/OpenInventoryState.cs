namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class OpenInventoryState : IGameState
    {
        private int transitionSpeed;
        private int lockout;

        public OpenInventoryState()
        {
            this.lockout = -174;
            this.transitionSpeed = 5;
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
            if (lockout > LoZGame.Instance.ScreenHeight - (2 * LoZGame.Instance.InventoryOffset))
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
            if (this.lockout <= LoZGame.Instance.ScreenHeight - (2 * LoZGame.Instance.InventoryOffset))
            {
                InventoryComponents.Instance.InventoryBackgroundPositionY += transitionSpeed;
            }
        }

        /// <inheritdoc></inheritdoc>
        public void Draw()
        {
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);

            foreach (IPlayer player in LoZGame.Instance.Players)
            {
                player.Draw();
            }
            LoZGame.Instance.GameObjects.Draw();
            InventoryComponents.Instance.DrawCorrectBackground();

            LoZGame.Instance.SpriteBatch.End();

            // Ensure inventory objects draw above the game objects while transitioning.
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);

            InventoryComponents.Instance.DrawInventoryElements();

            LoZGame.Instance.SpriteBatch.End();
        }
    }
}