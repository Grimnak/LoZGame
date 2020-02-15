
namespace LoZClone
{
    public class CommandBlockRight : ICommand
    {
        BlockManager block;
        public CommandBlockRight(BlockManager block)
        {
            this.block = block;
        }
        public void execute()
        {
            block.cycleRight();
        }
    }
}