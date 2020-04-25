namespace LoZClone
{
    /// <summary>
    /// Command that triggers the inventory screen.
    /// </summary>
    public class CommandPause : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandPause"/> class.
        /// </summary>
        public CommandPause()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            if (LoZGame.Instance.GameState is PauseState)
            {
                LoZGame.Instance.GameState.Unpause();
            }
            else
            {
                LoZGame.Instance.GameState.Pause();
            }
        }
    }
}