namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeathState : IGameState
    {
        private int deathTime;
        private int deathTimeMax;
        private int gameOverTime;
        private ISprite sprite;

        public DeathState()
        {
            this.deathTime = 0;
            this.deathTimeMax = GameData.Instance.GameStateDataConstants.DeathTimeMax;
            this.gameOverTime = GameData.Instance.GameStateDataConstants.GameOverTime;
            this.sprite = ScreenSpriteFactory.Instance.GameOverScreen();
        }

        /// <inheritdoc></inheritdoc>
        public void Death()
        {
            // Can't transition to a state you're already in.
        }

        /// <inheritdoc></inheritdoc>
        public void OpenInventory()
        {
            // Can't access inventory while dead.
        }

        /// <inheritdoc></inheritdoc>
        public void CloseInventory()
        {
            // Can't close inventory when it's not open.
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
        public void TransitionRoom(Physics.Direction direction)
        {
            // Can't transition room while dead.
        }

        /// <inheritdoc></inheritdoc>
        public void WinGame()
        {
            // Can't win game while dead.
        }

        /// <inheritdoc></inheritdoc>
        public void Update()
        {
            this.deathTime++;
            if (this.deathTime < deathTimeMax)
            {
                foreach (IPlayer player in LoZGame.Instance.Players)
                {
                    player.Update();
                }
            }
            else if (this.deathTime > gameOverTime)
            {
                LoZGame.Instance.GameState.TitleScreen();
            }
        }

        /// <inheritdoc></inheritdoc>
        public void Draw()
        {
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            InventoryComponents.Instance.DrawCorrectBackground();
            LoZGame.Instance.GameObjects.Draw();

            if (this.deathTime < deathTimeMax)
            {
                foreach (IPlayer player in LoZGame.Instance.Players)
                {
                    player.Draw();
                }
            }
            else if (this.deathTime > deathTimeMax && this.deathTime < gameOverTime)
            {
                LoZGame.Instance.SpriteBatch.End();
                LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
                this.sprite.Draw(new Vector2(0, 0), Color.White, 0);
            }
            LoZGame.Instance.SpriteBatch.End();
        }
    }
}