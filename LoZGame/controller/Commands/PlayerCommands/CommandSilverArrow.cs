namespace LoZClone
{
    /// <summary>
    /// Command that makes player shoot a silver arrow.
    /// </summary>
    public class CommandSilverArrow : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandSilverArrow"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandSilverArrow(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            this.player.Inventory.SelectedItem = InventoryManager.ItemType.SilverArrow;
        }
    }
}