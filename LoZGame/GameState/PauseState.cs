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
            this.previousState = gameState;
            this.PauseScreen = ScreenSpriteFactory.Instance.PauseScreen();
        }

        public override void Unpause()
        {
            LoZGame.Instance.GameState = new UnpauseState(this.previousState);
        }

        /// <inheritdoc></inheritdoc>
        public override void Draw()
        {
            this.previousState.Draw();
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            this.PauseScreen.Draw(Vector2.Zero, LoZGame.Instance.DungeonTint, 1);
            LoZGame.Instance.SpriteBatch.End();
        }
    }
}