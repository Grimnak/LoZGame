namespace LoZClone
{
    public class CommandAttackB : ICommand
    {
        IPlayer player;
        EntityManager entity;
        private static int priority = 7;
        public CommandAttackB(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }
        public void execute()
        {
            if (!((Link)player).IsDead)
            {
                player.attack();
                entity.ProjectileManager.addItem(entity.ProjectileManager.Swordbeam, (Link)player);
            }
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}