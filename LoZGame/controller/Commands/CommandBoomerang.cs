namespace LoZClone
{
    public class CommandBoomerang : ICommand
    {
        readonly IPlayer player;
        readonly EntityManager entity;
        private static readonly int priority = 6;

        public CommandBoomerang(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }

        public void execute()
        {
            if (!this.entity.ProjectileManager.BoomerangOut && !this.player.IsDead)
            {
                this.player.useItem(ProjectileManager.MaxWaitTime);
                this.entity.ProjectileManager.AddItem(this.entity.ProjectileManager.Boomerang, this.player);
            }
        }

        public int Priority => priority;
    }
}