namespace LoZClone
{
    /// <summary>
    /// Command that makes player hold a triforce above their head.
    /// </summary>
    public class CommandTriforce : ICommand
    {
        private static readonly int PriorityValue = 5;
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandTriforce"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandTriforce(IPlayer player)
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
                this.player.PickupItem(TriforceProjectile.LifeTime);
                EntityManager.Instance.ProjectileManager.AddItem(EntityManager.Instance.ProjectileManager.Triforce, this.player);
            }
        }
    }
}