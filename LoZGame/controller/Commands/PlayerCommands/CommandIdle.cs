namespace LoZGame
{
    /// <summary>
    /// Command that makes player idle.
    /// </summary>
    public class CommandIdle : ICommand
    {
        private static readonly int PriorityValue = 0;
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandIdle"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandIdle(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            this.player.Idle();
        }
    }
}