namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Command that makes the game reset to a default state.
    /// </summary>
    public class CommandContinue : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandContinue"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandContinue(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            player.Physics.Bounds = new Rectangle(
                    (int)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                    BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * 6),
                    player.Physics.Bounds.Width,
                    player.Physics.Bounds.Height);
            player.Physics.SetLocation();
            player.Physics.CurrentDirection = Physics.Direction.North;
            player.Physics.KnockbackVelocity = Vector2.Zero;
            player.State = new IdleState(player);
            player.Health.CurrentHealth = player.Health.MaxHealth / 2;
            player.DamageTimer = 0;
            player.CurrentTint = Color.White;

            LoZGame.Instance.Players[0].Inventory = new InventoryManager(((Link)LoZGame.Instance.Players[0]).BackupInventory);
            InventoryComponents.Instance.Reset();
            LoZGame.Instance.Dungeon.Reset();
            LoZGame.Instance.GameState.PlayGame();
        }
    }
}