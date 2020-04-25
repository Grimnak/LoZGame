namespace LoZClone
{
    /// <summary>
    /// Command that makes the player move up.
    /// </summary>
    public class CommandUp : ICommand
    {
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
        public void Execute()
        {
            player.MoveUp();
        }
    }
}