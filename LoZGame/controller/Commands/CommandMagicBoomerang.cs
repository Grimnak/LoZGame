namespace LoZClone
{
    public class CommandMagicBoomerang : ICommand
    {
        IPlayer player;
        EntityManager entity;
        private static int priority = 6;
        public CommandMagicBoomerang(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }
        public void execute()
        {
            if (!entity.ProjectileManager.BoomerangOut && !player.IsDead)
            {
                player.useItem(ProjectileManager.MaxWaitTime);
                entity.ProjectileManager.addItem(entity.ProjectileManager.MagicBoomerang, player);
            }
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}