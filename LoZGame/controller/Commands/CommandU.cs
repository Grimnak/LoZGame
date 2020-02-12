
namespace LoZClone
{
    public class CommandK: ICommand
    {
        BlockManager block;
        public CommandK(BlockManager block)
        {
            this.block = block;
        }
        public void execute()
        {
            block.cycleLeft();
        }
    }
}