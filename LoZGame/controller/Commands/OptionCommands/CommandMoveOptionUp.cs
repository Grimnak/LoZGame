namespace LoZClone
{
    /// <summary>
    /// Command that changes the currently selected option up one unit of option.
    /// </summary>
    public class CommandMoveOptionUp : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandMoveOptionUp"/> class.
        /// </summary>
        public CommandMoveOptionUp()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            LoZGame.Instance.Options.MoveSelectionUp();
        }
    }
}