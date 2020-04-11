namespace LoZClone
{
    /// <summary>
    /// Command that triggers the inventory screen.
    /// </summary>
    public class CommandInventory : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandInventory"/> class.
        /// </summary>
        public CommandInventory()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            if (LoZGame.Instance.GameState is PlayGameState)
            {
                LoZGame.Instance.GameState.OpenInventory();
            }
            else if (LoZGame.Instance.GameState is OpenInventoryState)
            {
                LoZGame.Instance.GameState.CloseInventory();
            }
        }
    }
}