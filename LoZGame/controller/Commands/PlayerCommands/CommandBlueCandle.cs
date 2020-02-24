namespace LoZClone
{
    /// <summary>
    /// Command that makes player shoot a flame from the blue candle.
    /// </summary>
    public class CommandBlueCandle : ICommand
    {
        private static readonly int PriorityValue = 6;
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBlueCandle"/> class.
        /// </summary>
        /// <param name="player">The player to execute a command on.</param>
        public CommandBlueCandle(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            if (!EntityManager.Instance.ProjectileManager.FlameInUse && !(this.player.State is DieState))
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                EntityManager.Instance.ProjectileManager.AddItem(EntityManager.Instance.ProjectileManager.BlueCandle, this.player);
            }
        }

        public int Priority => PriorityValue;
    }
}