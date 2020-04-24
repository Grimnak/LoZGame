namespace LoZClone
{
    /// <summary>
    /// Command that changes the currently selected option.
    /// </summary>
    public class CommandToggleOptions : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandToggleOptions"/> class.
        /// </summary>
        public CommandToggleOptions()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            LoZGame.Instance.Exit();
        }
    }
}