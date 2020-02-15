namespace LoZClone
{
    public class CommandZ : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        public CommandZ(IPlayer player, ProjectileManager projectile)
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