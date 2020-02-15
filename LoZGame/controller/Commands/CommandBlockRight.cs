
namespace LoZClone
{
    public class CommandBlockRight : ICommand
    {
        BlockManager block;
        private static int priority = -1;
        public CommandBlockRight(BlockManager block)
        {
            this.block = block;
        }
        public void execute()
        {
            block.cycleRight();
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}