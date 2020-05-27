namespace LoZClone
{
    /// <summary>
    /// Command that changes the currently selected profile down one.
    /// </summary>
    public class CommandMoveProfileDown : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandMoveProfileDown"/> class.
        /// </summary>
        public CommandMoveProfileDown()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            LoZGame.Instance.Profiles.MoveSelectionDown();
        }
    }
}