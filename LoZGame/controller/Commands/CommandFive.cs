namespace LoZClone
{
    public class CommandFive : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        public CommandFive(IPlayer player, ProjectileManager projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }
        public void execute()
        {
            //player.useSecondaryItem();
            projectile.addItem(projectile.SilverArrow, ((Link)player).CurrentLocation, ((Link)player).CurrentDirection);
        }
    }
}