namespace LoZClone
{
    /// <summary>
    /// Command that makes player throw a magic boomerang.
    /// </summary>
    public class CommandMagicBoomerang : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandMagicBoomerang"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandMagicBoomerang(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            this.player.Inventory.SelectedItem = InventoryManager.ItemType.MagicBoomerang;
        }
    }
}