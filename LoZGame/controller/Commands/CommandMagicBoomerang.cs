namespace LoZClone
{
    public class CommandMagicBoomerang : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        public CommandMagicBoomerang(IPlayer player, ProjectileManager projectile)
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