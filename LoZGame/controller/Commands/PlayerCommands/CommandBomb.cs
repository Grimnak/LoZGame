namespace LoZGame
{
    /// <summary>
    /// Command that makes player place a bomb.
    /// </summary>
    public class CommandBomb : ICommand
    {
        private static readonly int PriorityValue = 5;
        private readonly IPlayer player;
        private readonly EntityManager entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBomb"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        /// <param name="entity">Entity manager to execute a command on.</param>
        public CommandBomb(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            if (!(this.player.State is DieState))
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                this.entity.ProjectileManager.AddItem(this.entity.ProjectileManager.Bomb, this.player);
            }
        }
    }
}