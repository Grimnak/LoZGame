namespace LoZClone
{
    /// <summary>
    /// Command that makes player attack.
    /// </summary>
    public class CommandAttackA : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandAttackA"/> class.
        /// </summary>
        /// <param name="player">The player to execute a command on.</param>
        public CommandAttackA(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            if (!(player.State is DieState || player.State is PickupItemState || player.State is GrabbedState || player.State is StunnedState) && !LoZGame.Instance.GameObjects.Entities.ProjectileManager.PrimaryAttackLock && player.DisarmedTimer <= 0)
            {
                player.Attack();
                LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.WoodenSword, player);
                if (player.Health.CurrentHealth == player.Health.MaxHealth)
                {
                    LoZGame.Instance.GameObjects.Entities.ProjectileManager.AddItem(LoZGame.Instance.GameObjects.Entities.ProjectileManager.Swordbeam, player);
                }
            }
        }
    }
}