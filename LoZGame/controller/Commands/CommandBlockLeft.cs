
namespace LoZClone
{
    public class CommandBlockLeft: ICommand
    {
        BlockManager block;
        private static int priority = -1;
        public CommandBlockLeft(BlockManager block)
        {
            this.block = block;
        }
        public void execute()
        {
            block.cycleLeft();
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}