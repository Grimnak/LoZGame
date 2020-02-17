namespace LoZClone
{
    public class CommandDamage : ICommand
    {
        private static readonly int PriorityValue = -1;
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandDamage"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandDamage(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            this.player.takeDamage();
        }
    }
}