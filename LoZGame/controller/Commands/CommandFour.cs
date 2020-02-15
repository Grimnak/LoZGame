namespace LoZClone
{
    public class CommandFour : ICommand
    {
        IPlayer player;
        InventoryManager inventory;
        public CommandFour(IPlayer player, InventoryManager inventory)
        {
            this.player = player;
            this.inventory = inventory;
        }
        public void execute()
        {
            player.useItem();
            inventory.addItem(inventory.BlueCandle, ((Link)player).CurrentLocation, ((Link)player).CurrentDirection);
        }
    }
}