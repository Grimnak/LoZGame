namespace LoZClone
{
    /// <summary>
    /// Command that makes player place a bomb.
    /// </summary>
    public class CommandBomb : ICommand
    {
        private static readonly int PriorityValue = 5;
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBomb"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandBomb(IPlayer player)
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
                EntityManager.Instance.ProjectileManager.AddItem(EntityManager.Instance.ProjectileManager.Bomb, this.player);
            }
        }
    }
}