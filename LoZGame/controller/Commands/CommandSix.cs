namespace LoZClone
{
    public class CommandSix : ICommand
    {
        IPlayer player;
        InventoryManager inventory;
        public CommandSix(IPlayer player, InventoryManager inventory)
        {
            this.player = player;
            this.inventory = inventory;
        }
        public void execute()
        {
            //player.useSecondaryItem();
            inventory.addItem(InventoryManager.ItemType.MagicBoomerang, (Link)player);
        }
    }
}