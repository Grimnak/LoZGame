
namespace LoZClone
{
    public class CommandBlockRight : ICommand
    {
        readonly BlockManager block;
        private static readonly int PriorityValue = -1;

        public CommandBlockRight(BlockManager block)
        {
            this.block = block;
        }

        public void execute()
        {
            this.block.cycleRight();
        }

        public int Priority => PriorityValue;
    }
}