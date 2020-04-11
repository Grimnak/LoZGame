namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class WinGameState : IGameState
    {

        private int currentDungeon;
        private static int maxDungeon = 2;
        private int lockout;
        private int lockoutMax = 440;

        public WinGameState()
        {
            lockout = 0;
            currentDungeon = 1;
        }

        /// <inheritdoc></inheritdoc>
        public void Death()
        {
            // Can't die while winning.
        }

        /// <inheritdoc></inheritdoc>
        public void OpenInventory()
        {
            // Can't access inventory while winning.
        }

        /// <inheritdoc></inheritdoc>
        public void CloseInventory()
        {
            // Can't close inventory when it's not open.
        }

        /// <inheritdoc></inheritdoc>
        public void PlayGame()
        {
            SoundFactory.Instance.PlayDungeonSong();
            LoZGame.Instance.GameState = new PlayGameState();
        }

        /// <inheritdoc></inheritdoc>
        public void TitleScreen()
        {
            LoZGame.Instance.GameState = new TitleScreenState();
        }

        /// <inheritdoc></inheritdoc>
        public void TransitionRoom(string direction)
        {
            // Can't transition room while winning.
        }

        /// <inheritdoc></inheritdoc>
        public void WinGame()
        {
            // Can't transition to a state you're already in.
        }

        /// <inheritdoc></inheritdoc>
        public void Update()
        {
            this.lockout++;

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
                    LoZGame.Instance.Dungeon = new Dungeon(LoZGame.Instance.Dungeon.DungeonNumber + 1);
                    LoZGame.Instance.Dungeon.Player = LoZGame.Instance.Players[0];
                    LoZGame.Instance.Players[0].Inventory.HasMap = false;
                    LoZGame.Instance.Players[0].Inventory.HasCompass = false;
                    LoZGame.Instance.CollisionDetector = new CollisionDetection(LoZGame.Instance.Dungeon);
                    LoZGame.Instance.GameState.PlayGame();
                }
                else
                {
                    LoZGame.Instance.GameState.TitleScreen();
                }
            }

        }

        /// <inheritdoc></inheritdoc>
        public void Draw()
        {
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            LoZGame.Instance.SpriteBatch.Draw(LoZGame.Instance.Background, new Rectangle(0, LoZGame.Instance.InventoryOffset, LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset), new Rectangle(0, 0, 236, 160), LoZGame.Instance.DungeonTint, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0f);

            foreach (IPlayer player in LoZGame.Instance.Players)
            {
                player.Draw();
            }

            LoZGame.Instance.GameObjects.Draw();
            LoZGame.Instance.SpriteBatch.End();

            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            InventoryComponents.Instance.DrawInventoryElements();
            // LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, "Health: " + LoZGame.Instance.Link.Health.CurrentHealth.ToString() + " | Bombs: " + LoZGame.Instance.Link.Inventory.Bombs.ToString() + " | Rupees: " + LoZGame.Instance.Link.Inventory.Rupees.ToString(), new Vector2(0,0), Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 1.0f);
            LoZGame.Instance.SpriteBatch.End();
        }
    }
}