namespace LoZGame
{
    /// <summary>
    /// Command that makes player attack.
    /// </summary>
    public class CommandAttackA : ICommand
    {
        private static readonly int PriorityValue = 7;
        private readonly IPlayer player;
        private readonly EntityManager entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandAttackA"/> class.
        /// </summary>
        /// <param name="player">The player to execute a command on.</param>
        /// <param name="entity">The entity manager to execute a command on.</param>
        public CommandAttackA(IPlayer player, EntityManager entity)
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
                this.player.Attack();
                this.entity.ProjectileManager.AddItem(this.entity.ProjectileManager.Swordbeam, this.player);
            }
        }
    }
}