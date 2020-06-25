namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class CloseInventoryState : GameStateEssentials, IGameState
    {
        private int transitionSpeed;
        private int lockout;

        public CloseInventoryState()
        {
            lockout = 0;
            transitionSpeed = GameData.Instance.GameStateDataConstants.CloseInventoryTransitionSpeed;
        }

        /// <inheritdoc></inheritdoc>
        public override void PlayGame()
        {
            LoZGame.Instance.GameState = new PlayGameState();
        }

        /// <inheritdoc></inheritdoc>
        public override void TitleScreen()
        {
            LoZGame.Instance.GameState = new TitleScreenState();
        }

        public override void Pause()
        {
            LoZGame.Instance.GameState = new PauseState(this);
        }

        /// <inheritdoc></inheritdoc>
        public override void Update()
        {
            lockout += transitionSpeed;
            if (lockout <= LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset)
            {
                InventoryComponents.Instance.InventoryBackgroundPositionY -= transitionSpeed;
            }
            else
            {
                LoZGame.Instance.GameState.PlayGame();
            }
        }

        /// <inheritdoc></inheritdoc>
        public override void Draw()
        {
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, LoZGame.Instance.BetterTinting);
            LoZGame.Instance.Dungeon.CurrentRoom.Draw(Point.Zero);
            LoZGame.Instance.SpriteBatch.End();

            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, LoZGame.Instance.BetterTinting);
            LoZGame.Instance.GameObjects.Draw();
            LoZGame.Instance.SpriteBatch.End();

            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            LoZGame.Instance.GameObjects.Enemies.Draw();
            LoZGame.Instance.GameObjects.Entities.Draw();
            LoZGame.Instance.Dungeon.DrawText();
            foreach (IPlayer player in LoZGame.Instance.Players)
            {
                player.Draw();
            }
            LoZGame.Instance.SpriteBatch.End();

            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            InventoryComponents.Instance.DrawInventoryElements();
            LoZGame.Instance.SpriteBatch.End();
        }
    }
}