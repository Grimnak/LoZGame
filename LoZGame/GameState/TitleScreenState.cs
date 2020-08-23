namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class TitleScreenState : GameStateEssentials, IGameState
    {
        private readonly ISprite sprite;
        private readonly ISprite enter;
        private readonly Color spriteTint = Color.White;

        public TitleScreenState()
        {
            SoundFactory.Instance.StopCreditsSong();
            SoundFactory.Instance.StopDungeonSong();
            SoundFactory.Instance.StopBossSong();
            SoundFactory.Instance.PlayTitleSong();
            sprite = ScreenSpriteFactory.Instance.TitleScreen();
            enter = ScreenSpriteFactory.Instance.PressEnter();
            sprite.FrameDelay = GameData.Instance.GameStateDataConstants.TitleScreenFrameDelay;
            LoZGame.Instance.GameObjects.Clear();
            LoZGame.Instance.Players.Clear();

            LoZGame.Instance.Link = new Link(new Vector2(
                    (float)(BlockSpriteFactory.Instance.HorizontalOffset + GameData.Instance.GameStateDataConstants.HorizontalHalfDungeon),
                    (float)(BlockSpriteFactory.Instance.TopOffset + GameData.Instance.GameStateDataConstants.VerticalHalfDungeon)));

            LoZGame.Instance.Players.Add(LoZGame.Instance.Link);

            KeyboardCommandLoader keyboardLoader = new KeyboardCommandLoader(LoZGame.Instance.Players[0]);
            MouseCommandLoader mouseLoader = new MouseCommandLoader();
            if (LoZGame.Instance.Controllers.Count == 0)
            {
                LoZGame.Instance.Controllers.Add(new KeyboardController(keyboardLoader));
                LoZGame.Instance.Controllers.Add(new MouseController(mouseLoader));
            }
            else
            {
                for (int i = 0; i < LoZGame.Instance.Controllers.Count; i++)
                {
                    if (LoZGame.Instance.Controllers[i] is KeyboardController)
                    {
                        LoZGame.Instance.Controllers[i] = new KeyboardController(keyboardLoader);
                    }
                    else if (LoZGame.Instance.Controllers[i] is MouseController)
                    {
                        LoZGame.Instance.Controllers[i] = new MouseController(mouseLoader);
                    }
                }
            }
        }

        /// <inheritdoc></inheritdoc>
        public override void ProfilesScreen()
        {
            SoundFactory.Instance.StopAll();
            LoZGame.Instance.GameState = new ProfilesState();
        }

        /// <inheritdoc></inheritdoc>
        public override void TitleScreen()
        {
            // Can perform a hard reset while in this state already.
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
            sprite.Update();
            for (int i = 0; i < LoZGame.Instance.Controllers.Count; i++)
            {
                LoZGame.Instance.Controllers[i].Update();
            }

            // temporary reset
            // CommandReset temp = new CommandReset(LoZGame.Instance.Players[0]);
            // temp.Execute();
        }

        /// <inheritdoc></inheritdoc>
        public override void Draw()
        {
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            sprite.Draw(new Vector2(0, 0), spriteTint, 1.0f);
            if (sprite.CurrentFrame > 3)
                enter.Draw(new Vector2(GameData.Instance.GameStateDataConstants.TitleDrawX, GameData.Instance.GameStateDataConstants.TitleDrawY), spriteTint, 1.0f);
            LoZGame.Instance.SpriteBatch.End();
        }
    }
}