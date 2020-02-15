namespace LoZClone
{
    public class CommandBoomerang : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        private static int priority = 5;
        public CommandBoomerang(IPlayer player, ProjectileManager projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }
        public void execute()
        {
            if (!projectile.BoomerangOut)
            {
                player.useItem();
                projectile.addItem(projectile.Boomerang, (Link)player);
            }
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}