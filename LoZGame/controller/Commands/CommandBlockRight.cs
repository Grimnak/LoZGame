namespace LoZClone
{
    /// <summary>
    /// Command that cycles current displayed block to the next one to its right.
    /// </summary>
    public class CommandBlockRight : ICommand
    {
        private static readonly int PriorityValue = -1;
        private readonly BlockManager block;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBlockRight"/> class.
        /// </summary>
        /// <param name="block">The block manager to execute a command on.</param>
        public CommandBlockRight(BlockManager block)
        {
            this.block = block;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            this.block.cycleRight();
        }
    }
}