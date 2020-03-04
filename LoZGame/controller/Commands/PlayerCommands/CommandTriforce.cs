namespace LoZClone
{
    /// <summary>
    /// Command that makes player hold a triforce above their head.
    /// </summary>
    public class CommandTriforce : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandTriforce"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandTriforce(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            if (!(this.player.State is DieState))
            {
                this.player.PickupItem(TriforceProjectileSprite.LifeTime);
                LoZGame.Instance.Entities.ProjectileManager.AddItem(LoZGame.Instance.Entities.ProjectileManager.Triforce, this.player);
            }
        }
    }
}