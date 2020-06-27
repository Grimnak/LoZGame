namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class PauseState : GameStateEssentials, IGameState
    {
        IGameState previousState;
        ISprite PauseScreen;
        private bool paused;

        public PauseState(IGameState gameState)
        {
            previousState = gameState;
            PauseScreen = ScreenSpriteFactory.Instance.PauseScreen();
        }

        public override void Unpause()
        {
            LoZGame.Instance.GameState = new UnpauseState(previousState);
        }

        /// <inheritdoc></inheritdoc>
        public override void ConfirmReset()
        {
            LoZGame.Instance.GameState = new ConfirmResetState(this);
        }

        /// <inheritdoc></inheritdoc>
        public override void ConfirmQuit()
        {
            LoZGame.Instance.GameState = new ConfirmQuitState(this);
        }

        /// <inheritdoc></inheritdoc>
        public override void Draw()
        {
            previousState.Draw();
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, LoZGame.Instance.BetterTinting);
            PauseScreen.Draw(Vector2.Zero, LoZGame.Instance.DefaultTint, 1);
            LoZGame.Instance.SpriteBatch.End();
        }
    }
}