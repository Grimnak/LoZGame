namespace LoZClone
{
    /// <summary>
    /// Command that makes player move to the left.
    /// </summary>
    public class CommandLeft : ICommand
    {
        private static readonly int PriorityValue = 1;
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLeft"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandLeft(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            this.player.MoveLeft();
        }
    }
}