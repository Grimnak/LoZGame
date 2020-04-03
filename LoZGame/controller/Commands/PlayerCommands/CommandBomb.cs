namespace LoZClone
{
    /// <summary>
    /// Command that makes player place a bomb.
    /// </summary>
    public class CommandBomb : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBomb"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandBomb(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            this.player.Inventory.SelectedItem = InventoryManager.ItemType.Bomb;
        }
    }
}