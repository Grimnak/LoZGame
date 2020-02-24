namespace LoZGame
{
    /// <summary>
    /// Command that makes player throw a magic boomerang.
    /// </summary>
    public class CommandMagicBoomerang : ICommand
    {
        private static readonly int PriorityValue = 6;
        private readonly IPlayer player;
        private readonly EntityManager entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandMagicBoomerang"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        /// <param name="entity">Entity manager to execute a command on.</param>
        public CommandMagicBoomerang(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            if (!this.entity.ProjectileManager.BoomerangOut && !(this.player.State is DieState))
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                this.entity.ProjectileManager.AddItem(this.entity.ProjectileManager.MagicBoomerang, this.player);
            }
        }
    }
}