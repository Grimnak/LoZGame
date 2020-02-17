
namespace LoZClone
{
    public class CommandItemRight : ICommand
    {
        readonly ItemManager item;
        private static readonly int PriorityValue = -1;

        public CommandItemRight(ItemManager item)
        {
            this.item = item;
        }

        public void execute()
        {
            this.item.cycleRight();
        }

        public int Priority => PriorityValue;
    }
}