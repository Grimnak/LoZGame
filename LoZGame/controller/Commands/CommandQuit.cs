namespace LoZClone
{
    /// <summary>
    /// Command that exits the game.
    /// </summary>
    public class CommandQuit : ICommand
    {
        private static readonly int PriorityValue = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandQuit"/> class.
        /// </summary>
        public CommandQuit()
        {
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            LoZGame.Instance.Exit();
        }
    }
}