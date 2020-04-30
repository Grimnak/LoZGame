namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class PlayGameState : GameStateEssentials, IGameState
    {
        public PlayGameState()
        {
        }

        /// <inheritdoc></inheritdoc>
        public override void Death()
        {
            LoZGame.Instance.GameState = new DeathState();
        }

        /// <inheritdoc></inheritdoc>
        public override void PlayFlute()
        {
            LoZGame.Instance.GameState = new FluteGameState();
        }

        /// <inheritdoc></inheritdoc>
        public override void OpenInventory()
        {
            LoZGame.Instance.GameState = new OpenInventoryState();
        }

        /// <inheritdoc></inheritdoc>
        public override void TitleScreen()
        {
            LoZGame.Instance.GameState = new TitleScreenState();
        }

        /// <inheritdoc></inheritdoc>
        public override void TransitionRoom(Physics.Direction direction)
        {
            if (!(LoZGame.Instance.Players[0].State is SwallowedState)) // -- potential bug --
            {
                LoZGame.Instance.GameState = new TransitionRoomState(direction);
            }
        }

        /// <inheritdoc></inheritdoc>
        public override void WinGame()
        {
            SoundFactory.Instance.StopAll();
            LoZGame.Instance.GameState = new TriforceState();
        }

        public override void Pause()
        {
            LoZGame.Instance.GameState = new PauseState(this);
        }

        public override void Options()
        {
            LoZGame.Instance.GameState = new OptionsState(this);
        }

        /// <inheritdoc></inheritdoc>
        public override void Update()
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