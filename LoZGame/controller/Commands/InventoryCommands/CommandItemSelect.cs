namespace LoZClone
{
    /// <summary>
    /// Command that selects players item.
    /// </summary>
    public class CommandItemSelect : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandItemSelect"/> class.
        /// </summary>
        /// <param name="player">The player to execute a command on.</param>
        public CommandItemSelect(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            player.Inventory.SelectItem();
        }
    }
}