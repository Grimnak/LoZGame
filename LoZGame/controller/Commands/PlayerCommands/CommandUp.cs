namespace LoZClone
{
    /// <summary>
    /// Command that maeks the player move up.
    /// </summary>
    public class CommandUp : ICommand
    {
        private static readonly int PriorityValue = 4;
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandUp"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandUp(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            this.player.MoveUp();
        }
    }
}