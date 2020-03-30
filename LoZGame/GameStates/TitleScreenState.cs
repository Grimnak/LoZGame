namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TitleScreenState : IGameState
    {
        public TitleScreenState()
        {
            LoZGame.Instance.GameObjects.Clear();
            LoZGame.Instance.Players.Clear();
            LoZGame.Instance.Controllers.Clear();

            LoZGame.Instance.Dungeon = new Dungeon(1);
            LoZGame.Instance.CollisionDetector = new CollisionDetection(LoZGame.Instance.Dungeon);

            LoZGame.Instance.Players.Add(new Link(new Vector2(
                    (float)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                    (float)(BlockSpriteFactory.Instance.VerticalOffset + (BlockSpriteFactory.Instance.TileHeight * 6)))));

            LoZGame.Instance.Dungeon.Player = LoZGame.Instance.Players[0];

            KeyboardCommandLoader keyboardLoader = new KeyboardCommandLoader(LoZGame.Instance.Players[0]);
            LoZGame.Instance.Controllers.Add(new KeyboardController(keyboardLoader));

            MouseCommandLoader mouseLoader = new MouseCommandLoader();
            LoZGame.Instance.Controllers.Add(new MouseController(mouseLoader));

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


            foreach (IController controller in LoZGame.Instance.Controllers)
            {
                controller.Update();
            }

            ///temporary reset
            //CommandReset temp = new CommandReset(LoZGame.Instance.Players[0]);
            //temp.Execute();
        }

        public void Draw()
        {
            // TODO
            LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, "TITLE SCREEN - PRESS ENTER", new Vector2(100, 100), Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
        }
    }
}
