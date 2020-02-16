namespace LoZClone
{
    public class CommandArrow: ICommand
    {
        private IPlayer player;
        private EntityManager entity;
        private static int priority = 5;
        public CommandArrow(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }
        public void execute()
        {
            if (!player.IsDead)
            {
                player.useItem(ProjectileManager.MaxWaitTime);
                entity.ProjectileManager.addItem(entity.ProjectileManager.Arrow, player);
            }
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}