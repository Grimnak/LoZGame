namespace LoZClone
{
    public class CommandSilverArrow : ICommand
    {
        IPlayer player;
        EntityManager entity;
        private static int priority = 5;
        public CommandSilverArrow(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }
        public void execute()
        {
            if (!player.IsDead)
            {
                player.useItem(ProjectileManager.MaxWaitTime);
                entity.ProjectileManager.addItem(entity.ProjectileManager.SilverArrow, player);
            }
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}