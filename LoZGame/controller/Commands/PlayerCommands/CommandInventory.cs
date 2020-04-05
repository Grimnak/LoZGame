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
            LoZGame.Instance.GameState = new InventoryState();
        }
    }
}