namespace LoZClone
{
    /// <summary>
    /// Command that makes player throw a boomerang.
    /// </summary>
    public class CommandBoomerang : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBoomerang"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandBoomerang(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            if (!LoZGame.Instance.Entities.ProjectileManager.BoomerangOut && !(this.player.State is DieState))
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.Entities.ProjectileManager.AddItem(LoZGame.Instance.Entities.ProjectileManager.Boomerang, this.player);
            }
        }
    }
}