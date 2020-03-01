namespace LoZClone
{
    /// <summary>
    /// Command that makes the player move right.
    /// </summary>
    public class CommandRight : ICommand
    {
        private static readonly int PriorityValue = 1;
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandRight"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandRight(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            this.player.MoveRight();
        }
    }
}