namespace LoZClone
{
    public class CommandOne : ICommand
    {
        IPlayer player;
        InventoryManager inventory;
        public CommandOne(IPlayer player,InventoryManager inventory)
        {
            this.player = player;
            this.inventory = inventory;
        }
        public void execute()
        {

            //player.useItem();
            inventory.addItem(InventoryManager.ItemType.Bomb,((Link)player).CurrentLocation,((Link)player).CurrentDirection);
            
        }
    }
}