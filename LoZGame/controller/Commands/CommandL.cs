
namespace LoZClone
{
    public class CommandL : ICommand
    {
        BlockManager block;
        public CommandL(BlockManager block)
        {
            this.block = block;
        }
        public void execute()
        {
            block.cycleRight();
        }
    }
}