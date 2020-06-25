namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class OpenInventoryState : GameStateEssentials, IGameState
    {
        private int transitionSpeed;
        private int lockout;

        public OpenInventoryState()
        {
            lockout = GameData.Instance.GameStateDataConstants.OpenInventoryLockout;
            transitionSpeed = GameData.Instance.GameStateDataConstants.OpenInventoryTransitionSpeed;
        }

        /// <inheritdoc></inheritdoc>
        public override void CloseInventory()
        {
            if (lockout > LoZGame.Instance.ScreenHeight - (2 * LoZGame.Instance.InventoryOffset))
            {
                LoZGame.Instance.GameState = new CloseInventoryState();
            }
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
            if (lockout <= LoZGame.Instance.ScreenHeight - (2 * LoZGame.Instance.InventoryOffset))
            {
                InventoryComponents.Instance.InventoryBackgroundPositionY += transitionSpeed;
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