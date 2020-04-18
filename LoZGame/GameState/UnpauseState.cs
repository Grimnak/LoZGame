namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UnpauseState : GameStateEssentials, IGameState
    {
        IGameState returnState;
        ISprite PauseScreen;
        private bool paused;

        public UnpauseState(IGameState gameState)
        {
            this.returnState = gameState;
            this.PauseScreen = ScreenSpriteFactory.Instance.PauseScreen();
        }

        public override void Update()
        {
            LoZGame.Instance.GameState = this.returnState;
        }

        /// <inheritdoc></inheritdoc>
        public override void Draw()
        {
            this.returnState.Draw();
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            this.PauseScreen.Draw(Vector2.Zero, LoZGame.Instance.DungeonTint, 1);
            LoZGame.Instance.SpriteBatch.End();
        }
    }
}