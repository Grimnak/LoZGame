namespace LoZClone
{
    public class CommandArrow : ICommand
    {
        private static readonly int PriorityValue = 5;
        private readonly IPlayer player;
        private readonly EntityManager entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandArrow"/> class.
        /// </summary>
        /// <param name="player">The player to execute a command on.</param>
        /// <param name="entity">The entity manager to execute a command on.</param>
        public CommandArrow(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            if (!this.player.IsDead)
            {
                this.player.useItem(ProjectileManager.MaxWaitTime);
                this.entity.ProjectileManager.AddItem(this.entity.ProjectileManager.Arrow, this.player);
            }
        }
    }
}