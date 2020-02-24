namespace LoZClone
{
    /// <summary>
    /// Command that makes player shoot an arrow.
    /// </summary>
    public class CommandArrow : ICommand
    {
        private static readonly int PriorityValue = 5;
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
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            if (!(this.player.State is DieState))
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                EntityManager.Instance.ProjectileManager.AddItem(EntityManager.Instance.ProjectileManager.Arrow, this.player);
            }
        }
    }
}