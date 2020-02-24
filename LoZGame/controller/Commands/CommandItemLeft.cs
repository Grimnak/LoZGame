namespace LoZClone
{
    /// <summary>
    /// Command that makes current item cycle to the next item to its left.
    /// </summary>
    public class CommandItemLeft : ICommand
    {
        private static readonly int PriorityValue = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandItemLeft"/> class.
        /// </summary>
        public CommandItemLeft()
        {
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            ItemManager.Instance.CycleLeft();
        }
    }
}