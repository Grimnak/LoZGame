
namespace LoZClone
{
    public class CommandItemRight : ICommand
    {
        ItemManager item;
        private static int priority = -1;
        public CommandItemRight(ItemManager item)
        {
            this.item = item;
        }
        public void execute()
        {
            item.cycleRight();
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}