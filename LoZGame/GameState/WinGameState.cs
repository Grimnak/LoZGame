namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class WinGameState : GameStateEssentials, IGameState
    {
        private const int flashRate = 40;
        private int maxDungeon;
        private int lockout;
        private int lockoutMax;
        private BlendState bs;

        public WinGameState()
        {
            maxDungeon = GameData.Instance.GameStateDataConstants.WinStateMaxDungeons;
            lockoutMax = GameData.Instance.GameStateDataConstants.WinStateMaxLockout;
            lockout = 0;
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
            LoZGame.Instance.GameState = new TitleScreenState();
        }

        public override void CreditsScreen()
        {
            SoundFactory.Instance.StopAll();
            LoZGame.Instance.GameState = new CreditsScreenState();
        }

        /// <inheritdoc></inheritdoc>
        public override void Update()
        {
            lockout++;

            // Triforce animation playing time
            if (lockout < lockoutMax)
            {
                foreach (IPlayer player in LoZGame.Instance.Players)
                {
                    player.Update();
                }

                LoZGame.Instance.GameObjects.Update();
            }
            else
            {
                // Transition to new dungeon or title screen.
                if (LoZGame.Instance.Dungeon.DungeonNumber < maxDungeon)
                {
                    LoZGame.Instance.Dungeon = new Dungeon(LoZGame.Instance.Dungeon.DungeonNumber + 1)
                    {
                        Player = LoZGame.Instance.Players[0]
                    };

                    LoZGame.Instance.Dungeon.LoadNewRoom();
                    LoZGame.Instance.Players[0].Inventory.HasMap = false;
                    LoZGame.Instance.Players[0].Inventory.HasCompass = false;
                    LoZGame.Instance.CollisionDetector = new CollisionDetection(LoZGame.Instance.Dungeon);
                    LoZGame.Instance.GameState.PlayGame();
                }
                else
                {
                    LoZGame.Instance.GameState.CreditsScreen();
                }
            }

        }

        /// <inheritdoc></inheritdoc>
        public override void Draw()
        {
            if (lockout > lockoutMax / 2 && lockout % flashRate <= (flashRate / 2))
            {
                bs = BlendState.NonPremultiplied;
            }
            else
            {
                bs = BlendState.NonPremultiplied;
            }
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, bs, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, LoZGame.Instance.BetterTinting);
            LoZGame.Instance.Dungeon.CurrentRoom.Draw(new Point(0, 0));

            foreach (IPlayer player in LoZGame.Instance.Players)
            {
                player.Draw();
            }

            LoZGame.Instance.GameObjects.Draw();
            LoZGame.Instance.SpriteBatch.End();

            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, bs, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            InventoryComponents.Instance.DrawInventoryElements();
            LoZGame.Instance.SpriteBatch.End();
        }
    }
}