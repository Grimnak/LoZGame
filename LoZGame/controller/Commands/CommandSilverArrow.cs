namespace LoZClone
{
    public class CommandSilverArrow : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        private static int priority = 5;
        public CommandSilverArrow(IPlayer player, ProjectileManager projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }
        public void execute()
        {
            //player.useSecondaryItem();
            projectile.addItem(projectile.SilverArrow, ((Link)player).CurrentLocation, ((Link)player).CurrentDirection);
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}