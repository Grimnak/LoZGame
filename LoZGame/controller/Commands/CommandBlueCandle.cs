namespace LoZClone
{
    public class CommandBlueCandle : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        private static int priority = 5;
        public CommandBlueCandle(IPlayer player, ProjectileManager projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }
        public void execute()
        {
            player.useItem();
            projectile.addItem(projectile.BlueCandle, ((Link)player).CurrentLocation, ((Link)player).CurrentDirection);
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}