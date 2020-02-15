namespace LoZClone
{
    public class CommandTriforce : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
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
    }
}