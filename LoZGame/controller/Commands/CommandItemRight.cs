namespace LoZClone
{
    /// <summary>
    /// Command that makes current item cycle to the next item to its rightt.
    /// </summary>
    public class CommandItemRight : ICommand
    {
        private static readonly int PriorityValue = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandItemRight"/> class.
        /// </summary>
        public CommandItemRight()
        {
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            ItemManager.Instance.CycleRight();
        }
    }
}