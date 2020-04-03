﻿namespace LoZClone
{
    /// <summary>
    /// Command that makes player shoot a flame from the red candle.
    /// </summary>
    public class CommandRedCandle : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandRedCandle"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandRedCandle(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            this.player.Inventory.SelectedItem = InventoryManager.ItemType.RedCandle;
        }
    }
}