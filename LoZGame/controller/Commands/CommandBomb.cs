namespace LoZClone
{
    public class CommandBomb : ICommand
    {
        IPlayer player;
        EntityManager entity;
        private static int priority = 5;
        public CommandBomb(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }
        public void execute()
        {
            if (!player.IsDead)
            {
                player.useItem(ProjectileManager.MaxWaitTime);
                entity.ProjectileManager.addItem(entity.ProjectileManager.Bomb, player);
            }
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}