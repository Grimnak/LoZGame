
namespace LoZClone
{
    public class CommandItemRight : ICommand
    {
        ItemManager item;
        public CommandItemRight(ItemManager item)
        {
            this.item = item;
        }
        public void execute()
        {
            item.cycleRight();
        }
    }
}