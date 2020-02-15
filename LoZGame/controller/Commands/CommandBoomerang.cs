namespace LoZClone
{
    public class CommandBoomerang : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        public CommandBoomerang(IPlayer player, ProjectileManager projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }
        public void execute()
        {
            
            projectile.addItem(projectile.Boomerang, (Link)player);
        }
    }
}