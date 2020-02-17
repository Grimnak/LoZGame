
namespace LoZClone
{
    public class CommandItemLeft : ICommand
    {
        readonly ItemManager item;
        private static readonly int priority = -1;

        public CommandItemLeft(ItemManager item)
        {
            this.item = item;
        }

        public void execute()
        {
            this.item.cycleLeft();
        }

        public int Priority => priority;
    }
}