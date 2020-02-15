namespace LoZClone
{
    public class CommandArrow: ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        public CommandArrow(IPlayer player, ProjectileManager projectile)
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