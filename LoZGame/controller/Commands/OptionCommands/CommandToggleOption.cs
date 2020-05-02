namespace LoZClone
{
    /// <summary>
    /// Command that mutates various settings that entire game.
    /// </summary>
    public class CommandToggleOption : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandToggleOption"/> class.
        /// </summary>
        public CommandToggleOption()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            LoZGame.Instance.Options.DetermineWhatToDo();
        }
    }
}