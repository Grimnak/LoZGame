namespace LoZClone
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
            if (!(player.State is DieState || player.State is PickupItemState || player.State is GrabbedState || player.State is StunnedState))
            {
                player.Inventory.UseItem();
            }
        }
    }
}