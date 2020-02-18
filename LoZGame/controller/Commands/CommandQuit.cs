namespace LoZClone
{
    /// <summary>
    /// Command that exits the game.
    /// </summary>
    public class CommandQuit : ICommand
    {
        private static readonly int PriorityValue = -1;
        private readonly LoZGame game;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandQuit"/> class.
        /// </summary>
        /// <param name="game">Game to execute a command on.</param>
        public CommandQuit(LoZGame game)
        {
            this.game = game;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            this.game.Exit();
        }
    }
}