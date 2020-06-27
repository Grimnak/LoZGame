namespace LoZClone
{
    /// <summary>
    /// Command that denies the exiting of the game.
    /// </summary>
    public class QuitCommandNo : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuitCommandNo"/> class.
        /// </summary>
        public QuitCommandNo()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            LoZGame.Instance.GameState.Unpause();
        }
    }
}