namespace LoZClone
{
    /// <summary>
    /// Command that makes current item cycle to the next item to its left.
    /// </summary>
    public class CommandItemLeft : ICommand
    {
        private static readonly int PriorityValue = -1;
        private readonly ItemManager item;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandItemLeft"/> class.
        /// </summary>
        /// <param name="item">Item manager to execute a command on.</param>
        public CommandItemLeft(ItemManager item)
        {
            this.item = item;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            this.item.cycleLeft();
        }
    }
}