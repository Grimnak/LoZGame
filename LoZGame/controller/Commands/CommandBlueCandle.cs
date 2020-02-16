namespace LoZClone
{
    public class CommandBlueCandle : ICommand
    {
        IPlayer player;
        EntityManager entity;
        private static int priority = 5;
        public CommandBlueCandle(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }
        public void execute()
        {
            if (!((Link)player).IsDead)
            {
                player.useItem();
                entity.ProjectileManager.addItem(entity.ProjectileManager.BlueCandle, ((Link)player));
            }
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}