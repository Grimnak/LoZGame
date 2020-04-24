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
        ISprite SelectorSprite;
        private Vector2 optionsOffset = new Vector2(GameData.Instance.GameStateDataConstants.OptionsWidthOffset, GameData.Instance.GameStateDataConstants.OptionsHeightOffset);

        public OptionsState(IGameState gameState)
        {
            previousState = gameState;
            SelectorSprite = InventorySpriteFactory.Instance.CreateInventoryItemSelector2();
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
            OptionsScreen.Draw(optionsOffset, LoZGame.Instance.DefaultTint, 0.9f);
            switch (LoZGame.Instance.Options.SelectedOption)
            {
                case LoZClone.Options.OptionType.Difficulty:
                    SelectorSprite.Draw(new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsSelectorY), LoZGame.Instance.DefaultTint, 0.99f);
                    break;
                case LoZClone.Options.OptionType.Cheats:
                    SelectorSprite.Draw(new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsSelectorY + GameData.Instance.GameStateDataConstants.OptionsTextLeading), LoZGame.Instance.DefaultTint, 0.99f);
                    break;
                case LoZClone.Options.OptionType.Debug:
                    SelectorSprite.Draw(new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsSelectorY + (2 * GameData.Instance.GameStateDataConstants.OptionsTextLeading)), LoZGame.Instance.DefaultTint, 0.99f);
                    break;
                default:
                    LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, "If you see this, call the police.", new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsCheatsY), Color.DarkRed);
                    break;
            }
            LoZGame.Instance.SpriteBatch.End();
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, LoZGame.Instance.BetterTinting);
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, DifficultyMapper.GetMyType(LoZGame.Instance.Difficulty).Name, new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsDifficultyY), Color.White);
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, string.Concat(LoZGame.Cheats), new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsCheatsY), Color.White);
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, string.Concat(LoZGame.DebugMode), new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsDebugY), Color.White);
            LoZGame.Instance.SpriteBatch.End();
        }
    }
}
