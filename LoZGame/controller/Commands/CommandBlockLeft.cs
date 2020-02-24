namespace LoZClone
{
    /// <summary>
    /// Command that cycles current displayed block to the next one to its left.
    /// </summary>
    public class CommandBlockLeft : ICommand
    {
        private static readonly int PriorityValue = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBlockLeft"/> class.
        /// </summary>
        public CommandBlockLeft()
        {
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            BlockManager.Instance.CycleLeft();
        }
    }
}