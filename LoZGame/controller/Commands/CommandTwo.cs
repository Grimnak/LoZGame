﻿namespace LoZClone
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
            inventory.addItem(inventory.Arrow, ((Link)player).CurrentLocation, ((Link)player).CurrentDirection);
        }
    }
}