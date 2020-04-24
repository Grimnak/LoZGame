using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class OptionsState : GameStateEssentials, IGameState
    {
        IGameState previousState;
        ISprite OptionsScreen;
        private Vector2 optionsOffset = new Vector2(GameData.Instance.GameStateDataConstants.OptionsWidthOffset, GameData.Instance.GameStateDataConstants.OptionsHeightOffset);

        public OptionsState(IGameState gameState)
        {
            previousState = gameState;
            OptionsScreen = ScreenSpriteFactory.Instance.OptionsScreen();
        }

        public override void Unpause()
        {
            LoZGame.Instance.GameState = new UnpauseState(previousState);
        }

        /// <inheritdoc></inheritdoc>
        public override void Draw()
        {
            previousState.Draw();
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, LoZGame.Instance.BetterTinting);
            OptionsScreen.Draw(optionsOffset, LoZGame.Instance.DefaultTint, 1);
            LoZGame.Instance.SpriteBatch.End();
        }
    }
}
