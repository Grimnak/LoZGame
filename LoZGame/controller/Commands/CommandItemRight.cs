
namespace LoZClone
{
    public class CommandItemRight : ICommand
    {
        readonly ItemManager item;
        private static readonly int priority = -1;

        public CommandItemRight(ItemManager item)
        {
            this.item = item;
        }

        public void execute()
        {
            this.item.cycleRight();
        }

        public int Priority => priority;
    }
}