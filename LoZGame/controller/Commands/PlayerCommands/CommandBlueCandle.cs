namespace LoZClone
{
    /// <summary>
    /// Command that makes player shoot a flame from the blue candle.
    /// </summary>
    public class CommandBlueCandle : ICommand
    {
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
            if (!LoZGame.Instance.GameObjects.Entities.ProjectileManager.FlameInUse && !(this.player.State is DieState || this.player.State is PickupItemState || this.player.State is GrabbedState))
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.BlueCandle, this.player);
            }
        }
    }
}