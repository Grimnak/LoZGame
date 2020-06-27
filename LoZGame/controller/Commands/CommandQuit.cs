namespace LoZClone
{
    /// <summary>
    /// Command that exits the game.
    /// </summary>
    public class CommandQuit : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandQuit"/> class.
        /// </summary>
        public CommandQuit()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            LoZGame.Instance.GameState.ConfirmQuit();
        }
    }
}