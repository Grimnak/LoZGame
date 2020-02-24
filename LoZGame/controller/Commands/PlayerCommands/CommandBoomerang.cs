namespace LoZClone
{
    /// <summary>
    /// Command that makes player throw a boomerang.
    /// </summary>
    public class CommandBoomerang : ICommand
    {
        private static readonly int PriorityValue = 6;
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBoomerang"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandBoomerang(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            if (!EntityManager.Instance.ProjectileManager.BoomerangOut && !(this.player.State is DieState))
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                EntityManager.Instance.ProjectileManager.AddItem(EntityManager.Instance.ProjectileManager.Boomerang, this.player);
            }
        }
    }
}