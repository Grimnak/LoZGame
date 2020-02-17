
namespace LoZClone
{
    public class CommandBlockLeft : ICommand
    {
        readonly BlockManager block;
        private static readonly int priority = -1;

        public CommandBlockLeft(BlockManager block)
        {
            this.block = block;
        }

        public void execute()
        {
            this.block.cycleLeft();
        }

        public int Priority => priority;
    }
}