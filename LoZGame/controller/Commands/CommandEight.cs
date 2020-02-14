namespace LoZClone
{
    public class CommandEight : ICommand
    {
        IPlayer player;
        InventoryManager inventory;
        public CommandEight(IPlayer player, InventoryManager inventory)
        {
            this.player = player;
            this.inventory = inventory;
        }
        public void execute()
        {
            //player.useSecondaryItem();
            inventory.addItem(inventory.Triforce, ((Link)player).CurrentLocation, ((Link)player).CurrentDirection);
        }
    }
}