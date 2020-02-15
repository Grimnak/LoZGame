namespace LoZClone
{
    public class CommandTriforce : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        private static int priority = 5;
        public CommandTriforce(IPlayer player, ProjectileManager projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }
        public void execute()
        {
            //player.useSecondaryItem();
            projectile.addItem(projectile.Triforce, ((Link)player).CurrentLocation, ((Link)player).CurrentDirection);
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}