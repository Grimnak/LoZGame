namespace LoZClone
{
    /// <summary>
    /// Command that makes player shoot a flame from the red candle.
    /// </summary>
    public class CommandRedCandle : ICommand
    {
        private static readonly int PriorityValue = 5;
        private readonly IPlayer player;
        private readonly EntityManager entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandRedCandle"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        /// <param name="entity">Entity manager to execute a command on.</param>
        public CommandRedCandle(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            if (!(this.player.State is DieState))
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                this.entity.ProjectileManager.AddItem(this.entity.ProjectileManager.RedCandle, this.player);
            }
        }
    }
}