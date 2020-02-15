
namespace LoZClone
{
    public class CommandBlockLeft: ICommand
    {
        BlockManager block;
        public CommandBlockLeft(BlockManager block)
        {
            this.block = block;
        }
        public void execute()
        {
            block.cycleLeft();
        }
    }
}