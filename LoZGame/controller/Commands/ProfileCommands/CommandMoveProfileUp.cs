namespace LoZClone
{
    /// <summary>
    /// Command that changes the currently selected profile up one.
    /// </summary>
    public class CommandMoveProfileUp : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandMoveProfileUp"/> class.
        /// </summary>
        public CommandMoveProfileUp()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            LoZGame.Instance.Profiles.MoveSelectionUp();
        }
    }
}