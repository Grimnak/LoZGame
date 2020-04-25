namespace LoZClone
{
    /// <summary>
    /// Command that changes the currently selected option down one unit of option.
    /// </summary>
    public class CommandMoveOptionDown : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandMoveOptionDown"/> class.
        /// </summary>
        public CommandMoveOptionDown()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            LoZGame.Instance.Options.MoveSelectionDown();
        }
    }
}