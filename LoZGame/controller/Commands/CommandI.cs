
namespace LoZClone
{
    public class CommandI : ICommand
    {
        ItemManager item;
        public CommandI(ItemManager item)
        {
            this.item = item;
        }
        public void execute()
        {
            item.cycleRight();
        }
    }
}