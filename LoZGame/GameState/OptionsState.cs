﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class OptionsState : GameStateEssentials, IGameState
    {
        IGameState previousState;
        ISprite OptionsScreen;
        ISprite SelectorSpriteFalse, SelectorSpriteTrue, SelectorSpriteEasy, SelectorSpriteNormal, SelectorSpriteHard, SelectorSpriteNightmare;
        private Vector2 optionsOffset = new Vector2(GameData.Instance.GameStateDataConstants.OptionsWidthOffset, GameData.Instance.GameStateDataConstants.OptionsHeightOffset);
        string cheatStr;
        string debugStr;
        string musicStr;

        public OptionsState(IGameState gameState)
        {
            previousState = gameState;
            SelectorSpriteFalse = InventorySpriteFactory.Instance.CreateInventoryItemSelectorFalse();
            SelectorSpriteTrue = InventorySpriteFactory.Instance.CreateInventoryItemSelectorTrue();
            SelectorSpriteEasy = InventorySpriteFactory.Instance.CreateInventoryItemSelectorEasy();
            SelectorSpriteNormal = InventorySpriteFactory.Instance.CreateInventoryItemSelectorNormal();
            SelectorSpriteHard = InventorySpriteFactory.Instance.CreateInventoryItemSelectorHard();
            SelectorSpriteNightmare = InventorySpriteFactory.Instance.CreateInventoryItemSelectorNightmare();
            OptionsScreen = ScreenSpriteFactory.Instance.OptionsScreen();
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
            OptionsScreen.Draw(optionsOffset, Color.White, 0.9f);
            switch (LoZGame.Instance.Options.SelectedOption)
            {
                case LoZClone.Options.OptionType.Difficulty:
                    switch (DifficultyMapper.GetMyType(LoZGame.Instance.Difficulty).ID)
                    {
                        case -1:
                            SelectorSpriteEasy.Draw(new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsSelectorY), Color.White, 0.99f);
                            break;
                        case 0:
                            SelectorSpriteNormal.Draw(new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsSelectorY), Color.White, 0.99f);
                            break;
                        case 1:
                            SelectorSpriteHard.Draw(new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsSelectorY), Color.White, 0.99f);
                            break;
                        case 3:
                            SelectorSpriteNightmare.Draw(new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsSelectorY), Color.White, 0.99f);
                            break;
                        default:
                            break;
                    }
                    break;
                case LoZClone.Options.OptionType.Cheats:
                    if (LoZGame.Cheats)
                    {
                        SelectorSpriteTrue.Draw(new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsSelectorY + GameData.Instance.GameStateDataConstants.OptionsTextLeading), Color.White, 0.99f);
                    }
                    else
                    {
                        SelectorSpriteFalse.Draw(new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsSelectorY + GameData.Instance.GameStateDataConstants.OptionsTextLeading), Color.White, 0.99f);
                    }
                    break;
                case LoZClone.Options.OptionType.Debug:
                    if (LoZGame.DebugMode)
                    {
                        SelectorSpriteTrue.Draw(new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsSelectorY + (2 * GameData.Instance.GameStateDataConstants.OptionsTextLeading)), Color.White, 0.99f);
                    }
                    else
                    {
                        SelectorSpriteFalse.Draw(new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsSelectorY + (2 * GameData.Instance.GameStateDataConstants.OptionsTextLeading)), Color.White, 0.99f);
                    }
                    break;
                case LoZClone.Options.OptionType.Music:
                    if (LoZGame.Music)
                    {
                        SelectorSpriteTrue.Draw(new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsSelectorY + (3 * GameData.Instance.GameStateDataConstants.OptionsTextLeading)), Color.White, 0.99f);
                    }
                    else
                    {
                        SelectorSpriteFalse.Draw(new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsSelectorY + (3 * GameData.Instance.GameStateDataConstants.OptionsTextLeading)), Color.White, 0.99f);
                    }
                    break;
                default:
                    break;
            }
            LoZGame.Instance.SpriteBatch.End();
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, LoZGame.Instance.BetterTinting);
            cheatStr = LoZGame.Cheats ? "ON" : "OFF";
            debugStr = LoZGame.DebugMode ? "ON" : "OFF";
            musicStr = LoZGame.Music ? "ON" : "OFF";
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, DifficultyMapper.GetMyType(LoZGame.Instance.Difficulty).Name, new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsDifficultyY), Color.White);
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, cheatStr, new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsCheatsY), Color.White);
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, debugStr, new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsDebugY), Color.White);
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, musicStr, new Vector2(GameData.Instance.GameStateDataConstants.OptionsTextX, GameData.Instance.GameStateDataConstants.OptionsMusicY), Color.White);
            LoZGame.Instance.SpriteBatch.End();
        }
    }
}
