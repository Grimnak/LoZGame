namespace LoZClone
{
    /// <summary>
    /// Command that cycles current displayed block to the next one to its right.
    /// </summary>
    public class CommandBlockRight : ICommand
    {
        private static readonly int PriorityValue = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBlockRight"/> class.
        /// </summary>
        public CommandBlockRight()
        {
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            BlockManager.Instance.cycleRight();
        }
    }
}