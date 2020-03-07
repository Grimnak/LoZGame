namespace LoZClone
{
    /// <summary>
    /// Command that makes player move down.
    /// </summary>
    public class CommandDown : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandDown"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandDown(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            this.player.MoveDown();
        }
    }
}