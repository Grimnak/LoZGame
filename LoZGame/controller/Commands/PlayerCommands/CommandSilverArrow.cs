namespace LoZClone
{
    /// <summary>
    /// Command that makes player shoot a silver arrow.
    /// </summary>
    public class CommandSilverArrow : ICommand
    {
        private readonly IPlayer player;


        /// <summary>
        /// Initializes a new instance of the <see cref="CommandSilverArrow"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandSilverArrow(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            if (!(this.player.State is DieState || this.player.State is PickupItemState))
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.Entities.ProjectileManager.AddItem(LoZGame.Instance.Entities.ProjectileManager.SilverArrow, this.player);
            }
        }
    }
}