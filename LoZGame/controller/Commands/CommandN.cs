namespace LoZClone
{
    public class CommandN : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        public CommandN(IPlayer player, ProjectileManager projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }
        public void execute()
        {
            player.attack();
            projectile.addItem(projectile.Swordbeam, (Link)player);
        }
    }
}