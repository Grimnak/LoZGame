namespace LoZClone
{
    public class CommandFour : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        public CommandFour(IPlayer player, ProjectileManager projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }
        public void execute()
        {
            //player.useSecondaryItem();
            projectile.addItem(projectile.BlueCandle, ((Link)player).CurrentLocation, ((Link)player).CurrentDirection);
        }
    }
}