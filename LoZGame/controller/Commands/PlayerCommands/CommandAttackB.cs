namespace LoZClone
{
    /// <summary>
    /// Command that makes player attack.
    /// </summary>
    public class CommandAttackB : ICommand
    {
        private static readonly int PriorityValue = 7;
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandAttackB"/> class.
        /// </summary>
        /// <param name="player">The player to execute a command on.</param>
        public CommandAttackB(IPlayer player)
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
                this.player.Attack();
                EntityManager.Instance.ProjectileManager.AddItem(EntityManager.Instance.ProjectileManager.Swordbeam, this.player);
            }
        }
    }
}