namespace LoZClone
{
    /// <summary>
    /// Command that moves item selection up.
    /// </summary>
    public class CommandSelectionUp : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandSelectionUp"/> class.
        /// </summary>
        /// <param name="player">The player to execute a command on.</param>
        public CommandSelectionUp(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            player.Inventory.MoveSelectionUp();
        }
    }
}