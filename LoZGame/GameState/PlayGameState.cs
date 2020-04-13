namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class PlayGameState : IGameState
    {
        public PlayGameState()
        {
        }

        /// <inheritdoc></inheritdoc>
        public void Death()
        {
            LoZGame.Instance.GameState = new DeathState();
        }

        /// <inheritdoc></inheritdoc>
        public void OpenInventory()
        {
            LoZGame.Instance.GameState = new OpenInventoryState();
        }

        /// <inheritdoc></inheritdoc>
        public void CloseInventory()
        {
            // Can't close inventory when it's not open.
        }

        /// <inheritdoc></inheritdoc>
        public void PlayGame()
        {
            // Can't transition into a state you are already in.
        }

        /// <inheritdoc></inheritdoc>
        public void TitleScreen()
        {
            LoZGame.Instance.GameState = new TitleScreenState();
        }

        /// <inheritdoc></inheritdoc>
        public void TransitionRoom(Physics.Direction direction)
        {
            LoZGame.Instance.GameState = new TransitionRoomState(direction);
        }

        /// <inheritdoc></inheritdoc>
        public void WinGame()
        {
            LoZGame.Instance.GameState = new WinGameState();
        }

        /// <inheritdoc></inheritdoc>
        public void Update()
        {
            if (LoZGame.Instance.Players[0].Inventory.HasClock)
            {
                LoZGame.Instance.Players[0].Inventory.ClockLockout++;
            }
            if (LoZGame.Instance.Players[0].Inventory.ClockLockout >= InventoryManager.ClockLockoutMax)
            {
                LoZGame.Instance.Players[0].Inventory.HasClock = false;
                LoZGame.Instance.Players[0].Inventory.ClockLockout = 0;
            }
            foreach (IPlayer player in LoZGame.Instance.Players)
            {
                player.Update();
            }
            LoZGame.Instance.GameObjects.Update();
            LoZGame.Instance.CollisionDetector.Update(LoZGame.Instance.Players.AsReadOnly(), LoZGame.Instance.GameObjects.Enemies.EnemyList.AsReadOnly(), LoZGame.Instance.GameObjects.Blocks.BlockList.AsReadOnly(), LoZGame.Instance.GameObjects.Doors.DoorList.AsReadOnly(), LoZGame.Instance.GameObjects.Items.ItemList.AsReadOnly(), LoZGame.Instance.GameObjects.Entities.PlayerProjectiles.AsReadOnly(), LoZGame.Instance.GameObjects.Entities.EnemyProjectiles.AsReadOnly());

        }

        /// <inheritdoc></inheritdoc>
        public void Draw()
        {
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            InventoryComponents.Instance.DrawCorrectBackground();
            LoZGame.Instance.SpriteBatch.End();
            LoZGame.Instance.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            LoZGame.Instance.GameObjects.Draw();

            InventoryComponents.Instance.DrawText();

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