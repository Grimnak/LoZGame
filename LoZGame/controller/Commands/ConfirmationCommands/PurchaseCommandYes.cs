namespace LoZClone
{
    /// <summary>
    /// Command that confirms the purchase of an item.
    /// </summary>
    public class PurchaseCommandYes : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseCommandYes"/> class.
        /// </summary>
        public PurchaseCommandYes()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            LoZGame.Instance.GameObjects.Items.Clear();
            LoZGame.Instance.Dungeon.CurrentRoom.SetText("USE THEM WISELY, ADVENTURER.");
            LoZGame.Instance.Dungeon.CurrentRoom.SetPurchaseText(string.Empty);
            LoZGame.Instance.Players[0].PurchaseLockout = LoZGame.Instance.UpdateSpeed * 2;
            LoZGame.Instance.Players[0].Inventory.PurchaseBombs();
            LoZGame.Instance.GameState.Unpause();
        }
    }
}