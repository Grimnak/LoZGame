namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class TitleScreenState : IGameState
    {
        private readonly ISprite sprite;
        private readonly ISprite enter;
        private readonly Color spriteTint = LoZGame.Instance.DungeonTint;
        private bool nextBlink;

        public TitleScreenState()
        {
            this.nextBlink = false;
            this.sprite = ScreenSpriteFactory.Instance.TitleScreen();
            this.enter = ScreenSpriteFactory.Instance.PressEnter();
            this.sprite.FrameDelay = 10;
            LoZGame.Instance.GameObjects.Clear();
            LoZGame.Instance.Players.Clear();

            LoZGame.Instance.Dungeon = new Dungeon(1);
            LoZGame.Instance.CollisionDetector = new CollisionDetection(LoZGame.Instance.Dungeon);

            LoZGame.Instance.Link = new Link(new Vector2(
                    (float)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                    (float)(BlockSpriteFactory.Instance.VerticalOffset + (BlockSpriteFactory.Instance.TileHeight * 6))));

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

        public void Death()
        {
            // Can't die on title screen.
        }

        public void Inventory()
        {
            // Can't access inventory on title screen.
        }

        public void PlayGame()
        {
            LoZGame.Instance.GameState = new PlayGameState();
        }

        public void TitleScreen()
        {
            // Can do a hard reset while in this state already.
            LoZGame.Instance.GameState = new TitleScreenState();
        }

        public void TransitionRoom()
        {
            // Can't transition room from title screen.
        }

        public void WinGame()
        {
            // Can't win game from the title screen.
        }

        public void Update()
        {
            // TODO update title screen image

            this.sprite.Update();
            for (int i = 0; i < LoZGame.Instance.Controllers.Count; i++)
            {
                LoZGame.Instance.Controllers[i].Update();
            }

            // temporary reset
            // CommandReset temp = new CommandReset(LoZGame.Instance.Players[0]);
            // temp.Execute();
        }

        public void Draw()
        {
            // TODO
            this.sprite.Draw(new Vector2(0, 0), this.spriteTint, 1.0f);
            if (this.sprite.CurrentFrame > 3)
                this.enter.Draw(new Vector2(284, 350), this.spriteTint, 1.0f);
            // LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, "TITLE SCREEN - PRESS ENTER " + this.sprite.CurrentFrame, new Vector2(100, 100), Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
        }
    }
}
