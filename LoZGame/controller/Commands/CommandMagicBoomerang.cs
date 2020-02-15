namespace LoZClone
{
    public class CommandMagicBoomerang : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        private static int priority = 5;
        public CommandMagicBoomerang(IPlayer player, ProjectileManager projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }
        public void execute()
        {
            if (!projectile.BoomerangOut && !((Link)player).IsDead)
            {
                player.useItem();
                projectile.addItem(projectile.MagicBoomerang, (Link)player);
            }
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}