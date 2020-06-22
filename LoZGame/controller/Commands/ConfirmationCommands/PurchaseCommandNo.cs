namespace LoZClone
{
    /// <summary>
    /// Command that denies the purchase of an item.
    /// </summary>
    public class PurchaseCommandNo : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseCommandNo"/> class.
        /// </summary>
        public PurchaseCommandNo()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            LoZGame.Instance.Players[0].PurchaseLockout = LoZGame.Instance.UpdateSpeed * 2;
            LoZGame.Instance.GameState.Unpause();
        }
    }
}