namespace LoZClone
{
    /// <summary>
    /// Command that moves item selection left.
    /// </summary>
    public class CommandSelectionLeft : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandSelectionLeft"/> class.
        /// </summary>
        /// <param name="player">The player to execute a command on.</param>
        public CommandSelectionLeft(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            player.Inventory.MoveSelectionLeft();
        }
    }
}