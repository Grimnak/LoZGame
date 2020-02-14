namespace LoZClone
{
    public class CommandEight : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        public CommandEight(IPlayer player, ProjectileManager projectile)
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