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
            //player.useThirdItem();
            inventory.addItem(InventoryManager.ItemType.Bomb, ((Link)player).CurrentLocation, ((Link)player).CurrentDirection);
        }
    }
}