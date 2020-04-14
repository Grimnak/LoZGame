namespace LoZClone
{
    /// <summary>
    /// Command that moves item selection down.
    /// </summary>
    public class CommandSelectionDown : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandSelectionDown"/> class.
        /// </summary>
        /// <param name="player">The player to execute a command on.</param>
        public CommandSelectionDown(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            player.Inventory.MoveSelectionDown();
        }
    }
}