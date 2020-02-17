namespace LoZClone
{
    public class CommandTriforce : ICommand
    {
        readonly IPlayer player;
        readonly EntityManager entity;
        private static readonly int PriorityValue = 5;

        public CommandTriforce(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }

        public void execute()
        {
            if (!this.player.IsDead)
            {
                this.player.pickupItem(TriforceProjectile.LifeTime);
                this.entity.ProjectileManager.AddItem(this.entity.ProjectileManager.Triforce, this.player);
            }
        }

        public int Priority => PriorityValue;
    }
}