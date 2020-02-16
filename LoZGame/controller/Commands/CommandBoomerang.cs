namespace LoZClone
{
    public class CommandBoomerang : ICommand
    {
        IPlayer player;
        EntityManager entity;
        private static int priority = 6;
        public CommandBoomerang(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }
        public void execute()
        {
            if (!entity.ProjectileManager.BoomerangOut && !player.IsDead)
            {
                player.useItem(ProjectileManager.MaxWaitTime);
                entity.ProjectileManager.addItem(entity.ProjectileManager.Boomerang, player);
            }
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}