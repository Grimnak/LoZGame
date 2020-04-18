namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class TitleScreenState : GameStateEssentials, IGameState
    {
        private readonly ISprite sprite;
        private readonly ISprite enter;
        private readonly Color spriteTint = LoZGame.Instance.DefaultTint;

        public TitleScreenState()
        {
            SoundFactory.Instance.StopDungeonSong();
            SoundFactory.Instance.PlayTitleSong();
            this.sprite = ScreenSpriteFactory.Instance.TitleScreen();
            this.enter = ScreenSpriteFactory.Instance.PressEnter();
            this.sprite.FrameDelay = GameData.Instance.GameStateDataConstants.TitleScreenFrameDelay;
            LoZGame.Instance.GameObjects.Clear();
            LoZGame.Instance.Players.Clear();

            LoZGame.Instance.Dungeon = new Dungeon(LoZGame.StartDungeon);
            LoZGame.Instance.CollisionDetector = new CollisionDetection(LoZGame.Instance.Dungeon);

            LoZGame.Instance.Link = new Link(new Vector2(
                    (float)(BlockSpriteFactory.Instance.HorizontalOffset + GameData.Instance.GameStateDataConstants.HorizontalHalfDungeon),
                    (float)(BlockSpriteFactory.Instance.TopOffset + GameData.Instance.GameStateDataConstants.VerticalHalfDungeon)));

            LoZGame.Instance.Players.Add(LoZGame.Instance.Link);

            LoZGame.Instance.Dungeon.Player = LoZGame.Instance.Link;

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
        public override void PlayGame()
        {
            SoundFactory.Instance.StopAll();
            SoundFactory.Instance.PlayDungeonSong();
            LoZGame.Instance.GameState = new PlayGameState();
        }

        /// <inheritdoc></inheritdoc>
        public override void TitleScreen()
        {
            // Can perform a hard reset while in this state already.
            LoZGame.Instance.GameState = new TitleScreenState();
        }

        /// <inheritdoc></inheritdoc>
        public override void Update()
        {
            this.sprite.Update();
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
            this.sprite.Draw(new Vector2(0, 0), this.spriteTint, 1.0f);
            if (this.sprite.CurrentFrame > 3)
                this.enter.Draw(new Vector2(GameData.Instance.GameStateDataConstants.TitleDrawX, GameData.Instance.GameStateDataConstants.TitleDrawY), this.spriteTint, 1.0f);
            LoZGame.Instance.SpriteBatch.End();
        }
    }
}