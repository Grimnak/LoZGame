namespace LoZClone
{
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