namespace LoZClone
{
    public class CommandThree : ICommand
    {
        IPlayer player;
        InventoryManager inventory;
        public CommandThree(IPlayer player, InventoryManager inventory)
        {
            this.player = player;
            this.inventory = inventory;
        }
        public void execute()
        {
            player.useItem();
            inventory.addItem(inventory.Boomerang, (Link)player);
        }
    }
}