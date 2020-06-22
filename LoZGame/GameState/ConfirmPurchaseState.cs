namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ConfirmPurchaseState : GameStateEssentials, IGameState
    {
        private IGameState previousState;
        private ISprite ConfirmScreen;
        private Vector2 optionsOffset = new Vector2(GameData.Instance.GameStateDataConstants.OptionsWidthOffset, GameData.Instance.GameStateDataConstants.OptionsHeightOffset);

        public ConfirmPurchaseState(IGameState gameState)
        {
            previousState = gameState;
            ConfirmScreen = ScreenSpriteFactory.Instance.ConfirmScreen();
        }

        public override void Unpause()
        {
            LoZGame.Instance.GameState = new UnpauseState(previousState);
        }

        public override void Update()
        {
            foreach (IPlayer player in LoZGame.Instance.Players)
            {
                if (player.PurchaseLockout > 0)
                {
                    player.PurchaseLockout--;
                }
            }
        }

        /// <inheritdoc></inheritdoc>
        public override void Draw()
        {
            previousState.Draw();
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, LoZGame.Instance.BetterTinting);
            ConfirmScreen.Draw(optionsOffset, LoZGame.Instance.DefaultTint, 1);
            LoZGame.Instance.SpriteBatch.End();
        }
    }
}