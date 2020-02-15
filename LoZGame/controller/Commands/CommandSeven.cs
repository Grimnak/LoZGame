namespace LoZClone
{
    public class CommandSeven : ICommand
    {
        IPlayer player;
        InventoryManager inventory;
        public CommandSeven(IPlayer player, InventoryManager inventory)
        {
            this.player = player;
            this.inventory = inventory;
        }
        public void execute()
        {
            player.useItem();
            inventory.addItem(inventory.RedCandle, ((Link)player).CurrentLocation, ((Link)player).CurrentDirection);
        }
    }
}