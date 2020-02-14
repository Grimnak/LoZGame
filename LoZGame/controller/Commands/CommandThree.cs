namespace LoZClone
{
    public class CommandThree : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        public CommandThree(IPlayer player, ProjectileManager projectile)
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