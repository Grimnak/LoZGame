namespace LoZClone
{
    /// <summary>
    /// Command that makes player throw a boomerang.
    /// </summary>
    public class CommandBoomerang : ICommand
    {
        private static readonly int PriorityValue = 6;
        private readonly IPlayer player;
        private readonly EntityManager entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBoomerang"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        /// <param name="entity">Entity manager to execute a command on.</param>
        public CommandBoomerang(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            if (!this.entity.ProjectileManager.BoomerangOut && !this.player.IsDead)
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                this.entity.ProjectileManager.AddItem(this.entity.ProjectileManager.Boomerang, this.player);
            }
        }
    }
}