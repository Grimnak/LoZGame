﻿namespace LoZClone
{
    /// <summary>
    /// Command that makes player use an item.
    /// </summary>
    public class CommandAttackB : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandAttackB"/> class.
        /// </summary>
        /// <param name="player">The player to execute a command on.</param>
        public CommandAttackB(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            if (!(this.player.State is DieState || this.player.State is PickupItemState || this.player.State is GrabbedState))
            {
                this.player.Inventory.UseItem();
            }
        }
    }
}