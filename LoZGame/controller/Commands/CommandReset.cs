namespace LoZClone
{
    /// <summary>
    /// Command that makes the game reset to a default state.
    /// </summary>
    public class CommandReset : ICommand
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandReset"/> class.
        /// </summary>
        public CommandReset()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            LoZGame.Instance.GameState.ConfirmReset();
        }
    }
}