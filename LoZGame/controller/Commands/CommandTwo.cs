namespace LoZClone
{
    public class CommandTwo : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        public CommandTwo(IPlayer player, ProjectileManager projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }
        public void execute()
        {   
            projectile.addItem(projectile.Arrow, ((Link)player).CurrentLocation, ((Link)player).CurrentDirection);
        }
    }
}