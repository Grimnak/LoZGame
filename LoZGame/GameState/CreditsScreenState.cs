using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class CreditsScreenState : GameStateEssentials, IGameState
    {
        private readonly ISprite sprite;
        private readonly Color spriteTint = Color.White;
        private int count;
        private int MAX = GameData.Instance.GameStateDataConstants.CreditsMAX;

        public CreditsScreenState()
        {
            count = 0;
            SoundFactory.Instance.PlayLobbyTune();
            sprite = ScreenSpriteFactory.Instance.CreditsScreen();
            LoZGame.Instance.GameObjects.Clear();
            LoZGame.Instance.Players.Clear();
            LoZGame.Instance.Profiles.ResetSaveFile();
        }

        /// <inheritdoc></inheritdoc>
        public override void TitleScreen()
        {
            // Can perform a hard reset while in this state already.
            SoundFactory.Instance.StopAll();
            
            LoZGame.Instance.GameState = new TitleScreenState();
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
        public override void Update()
        {
            count++;
            if (count == MAX)
            {
                SoundFactory.Instance.StopCreditsSong();
                LoZGame.Instance.GameState.TitleScreen();
            }  
        }

        /// <inheritdoc></inheritdoc>
        public override void Draw()
        {
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            sprite.Draw(new Vector2(0, 0), spriteTint, 1.0f);
            LoZGame.Instance.SpriteBatch.End();
        }
    }
}
