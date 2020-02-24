namespace LoZGame
{
    /// <summary>
    /// Command that makes player shoot a flame from the blue candle.
    /// </summary>
    public class CommandBlueCandle : ICommand
    {
        private static readonly int PriorityValue = 6;
        private readonly IPlayer player;
        private readonly EntityManager entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBlueCandle"/> class.
        /// </summary>
        /// <param name="player">The player to execute a command on.</param>
        /// <param name="entity">The entity manager to execute a command on.</param>
        public CommandBlueCandle(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }

        public void Execute()
        {
            if (!this.entity.ProjectileManager.FlameInUse && !this.player.IsDead)
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                this.entity.ProjectileManager.AddItem(this.entity.ProjectileManager.BlueCandle, this.player);
            }
        }

        public int Priority => PriorityValue;
    }
}