namespace LoZClone
{
    /// <summary>
    /// Command that makes player shoot a silver arrow.
    /// </summary>
    public class CommandSilverArrow : ICommand
    {
        private static readonly int PriorityValue = 5;
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
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            if (!(this.player.State is DieState))
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                EntityManager.Instance.ProjectileManager.AddItem(EntityManager.Instance.ProjectileManager.SilverArrow, this.player);
            }
        }
    }
}