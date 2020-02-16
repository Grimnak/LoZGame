namespace LoZClone
{
    public class CommandBlueCandle : ICommand
    {
        IPlayer player;
        EntityManager entity;
        private static int priority = 6;
        public CommandBlueCandle(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }
        public void execute()
        {
            if (!entity.ProjectileManager.FlameInUse && !((Link)player).IsDead)
            {
                player.useItem(ProjectileManager.MaxWaitTime);
                entity.ProjectileManager.addItem(entity.ProjectileManager.BlueCandle, ((Link)player));
            }
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}