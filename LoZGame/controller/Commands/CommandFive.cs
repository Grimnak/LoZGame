﻿namespace LoZClone
{
    public class CommandFive : ICommand
    {
        IPlayer player;
        InventoryManager inventory;
        public CommandFive(IPlayer player, InventoryManager inventory)
        {
            this.player = player;
            this.inventory = inventory;
        }
        public void execute()
        {
            //player.useSecondaryItem();
            inventory.addItem(InventoryManager.ItemType.Bomb, ((Link)player).CurrentLocation, ((Link)player).CurrentDirection);
        }
    }
}