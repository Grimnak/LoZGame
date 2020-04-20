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
        private readonly Color spriteTint = LoZGame.Instance.DefaultTint;
        private int count;
        private int MAX = GameData.Instance.GameStateDataConstants.CreditsMAX;

        public CreditsScreenState()
        {
            count = 0;
            SoundFactory.Instance.PlayCreditsTune();
            this.sprite = ScreenSpriteFactory.Instance.CreditsScreen();
            LoZGame.Instance.GameObjects.Clear();
            LoZGame.Instance.Players.Clear();
        }

        /// <inheritdoc></inheritdoc>
        public override void TitleScreen()
        {
            // Can perform a hard reset while in this state already.
            SoundFactory.Instance.StopAll();
            LoZGame.Instance.GameState = new TitleScreenState();
        }

        /// <inheritdoc></inheritdoc>
        public override void Update()
        {
            count++;
            if (count == MAX)
                LoZGame.Instance.GameState.TitleScreen();
        }

        /// <inheritdoc></inheritdoc>
        public override void Draw()
        {
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            this.sprite.Draw(new Vector2(0, 0), this.spriteTint, 1.0f);
            LoZGame.Instance.SpriteBatch.End();
        }
    }
}
