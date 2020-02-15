
namespace LoZClone
{
    public class CommandItemLeft : ICommand
    {
        ItemManager item;
        public CommandItemLeft(ItemManager item)
        {
            this.item = item;
        }
        public void execute()
        {
            item.cycleLeft();
        }
    }
}