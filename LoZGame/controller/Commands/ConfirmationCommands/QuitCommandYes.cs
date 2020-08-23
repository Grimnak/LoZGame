namespace LoZClone
{
    /// <summary>
    /// Command that confirms the exiting of the game.
    /// </summary>
    public class QuitCommandYes : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuitCommandYes"/> class.
        /// </summary>
        public QuitCommandYes()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            LoZGame.Instance.Exit();
        }
    }
}