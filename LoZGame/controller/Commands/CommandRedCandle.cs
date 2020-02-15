namespace LoZClone
{
    public class CommandRedCandle : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        public CommandRedCandle(IPlayer player, ProjectileManager projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }
        public void execute()
        {
            //player.useSecondaryItem();
            projectile.addItem(projectile.RedCandle, ((Link)player).CurrentLocation, ((Link)player).CurrentDirection);
        }
    }
}