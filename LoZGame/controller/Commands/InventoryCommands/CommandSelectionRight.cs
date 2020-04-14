namespace LoZClone
{
    /// <summary>
    /// Command that moves item selection right.
    /// </summary>
    public class CommandSelectionRight : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandSelectionRight"/> class.
        /// </summary>
        /// <param name="player">The player to execute a command on.</param>
        public CommandSelectionRight(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            player.Inventory.MoveSelectionRight();
        }
    }
}