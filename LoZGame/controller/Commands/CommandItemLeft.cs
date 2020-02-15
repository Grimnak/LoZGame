
namespace LoZClone
{
    public class CommandItemLeft : ICommand
    {
        ItemManager item;
        private static int priority = -1;
        public CommandItemLeft(ItemManager item)
        {
            this.item = item;
        }
        public void execute()
        {
            item.cycleLeft();
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}