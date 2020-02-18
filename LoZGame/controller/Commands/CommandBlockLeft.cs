namespace LoZClone
{
    /// <summary>
    /// Command that cycles current displayed block to the next one to its left.
    /// </summary>
    public class CommandBlockLeft : ICommand
    {
        private static readonly int PriorityValue = -1;
        private readonly BlockManager block;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBlockLeft"/> class.
        /// </summary>
        /// <param name="block">The block manager to execute a command on.</param>
        public CommandBlockLeft(BlockManager block)
        {
            this.block = block;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            this.block.CycleLeft();
        }
    }
}