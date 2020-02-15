namespace LoZClone
{
    public class CommandTwo : ICommand
    {
        IPlayer player;
        InventoryManager inventory;
        public CommandTwo(IPlayer player, InventoryManager inventory)
        {
            this.player = player;
            this.inventory = inventory;
        }
        public void execute()
        {
            player.useItem();
            inventory.addItem(inventory.Arrow, ((Link)player).CurrentLocation, ((Link)player).CurrentDirection);
        }
    }
}