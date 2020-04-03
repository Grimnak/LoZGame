namespace LoZClone
{
    /// <summary>
    /// Command that makes player shoot an arrow.
    /// </summary>
    public class CommandArrow : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandArrow"/> class.
        /// </summary>
        /// <param name="player">The player to execute a command on.</param>
        public CommandArrow(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            if (!(this.player.State is DieState || this.player.State is PickupItemState || this.player.State is GrabbedState))
            {
                this.player.Inventory.UseArrow();
            }
        }
    }
}