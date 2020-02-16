namespace LoZClone
{
    public class CommandMagicBoomerang : ICommand
    {
        IPlayer player;
        EntityManager entity;
        private static int priority = 5;
        public CommandMagicBoomerang(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }
        public void execute()
        {
            if (!entity.ProjectileManager.BoomerangOut && !((Link)player).IsDead)
            {
                player.useItem();
                entity.ProjectileManager.addItem(entity.ProjectileManager.MagicBoomerang, (Link)player);
            }
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}