namespace LoZClone
{
    /// <summary>
    /// Command that makes player shoot a flame from the blue candle.
    /// </summary>
    public class CommandBlueCandle : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBlueCandle"/> class.
        /// </summary>
        /// <param name="player">The player to execute a command on.</param>
        public CommandBlueCandle(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            this.player.Inventory.SelectedItem = InventoryManager.ItemType.BlueCandle;
        }
    }
}