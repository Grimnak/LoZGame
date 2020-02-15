namespace LoZClone
{
    public class CommandRedCandle : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        private static int priority = 5;
        public CommandRedCandle(IPlayer player, ProjectileManager projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }
        public void execute()
        {
            if (!((Link)player).IsDead)
            {
                player.useItem();
                projectile.addItem(projectile.RedCandle, ((Link)player).CurrentLocation, ((Link)player).CurrentDirection);
            }
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}