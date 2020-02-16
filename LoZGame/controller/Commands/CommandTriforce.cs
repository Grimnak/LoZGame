namespace LoZClone
{
    public class CommandTriforce : ICommand
    {
        IPlayer player;
        EntityManager entity;
        private static int priority = 5;
        public CommandTriforce(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }
        public void execute()
        {
            if (!((Link)player).IsDead)
            {
                player.pickupItem();
                entity.ProjectileManager.addItem(entity.ProjectileManager.Triforce, ((Link)player));
            }
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}