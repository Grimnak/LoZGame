namespace LoZClone
{
    public class CommandSix : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        public CommandSix(IPlayer player, ProjectileManager projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }
        public void execute()
        {
            //player.useSecondaryItem();
            projectile.addItem(projectile.MagicBoomerang, (Link)player);
        }
    }
}