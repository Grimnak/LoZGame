namespace LoZClone
{
    /// <summary>
    /// Command that denies the resetting of the game.
    /// </summary>
    public class ResetCommandNo : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResetCommandNo"/> class.
        /// </summary>
        public ResetCommandNo()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            LoZGame.Instance.GameState.Unpause();
        }
    }
}