namespace LoZClone
{
    /// <summary>
    /// Command that makes player attack.
    /// </summary>
    public class CommandAttackB : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandAttackB"/> class.
        /// </summary>
        /// <param name="player">The player to execute a command on.</param>
        public CommandAttackB(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            if (!(this.player.State is DieState) && !LoZGame.Instance.Entities.ProjectileManager.PrimaryAttackLock)
            {
                this.player.Attack();
                LoZGame.Instance.Entities.ProjectileManager.AddItem(LoZGame.Instance.Entities.ProjectileManager.WoodenSword, this.player);
                if (this.player.Health.CurrentHealth == this.player.Health.MaxHealth)
                {
                    LoZGame.Instance.Entities.ProjectileManager.AddItem(LoZGame.Instance.Entities.ProjectileManager.Swordbeam, this.player);
                }
            }
        }
    }
}