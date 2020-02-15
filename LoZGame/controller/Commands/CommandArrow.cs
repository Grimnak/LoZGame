namespace LoZClone
{
    public class CommandArrow: ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        private static int priority = 5;
        public CommandArrow(IPlayer player, ProjectileManager projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }
        public void execute()
        {
            if (!((Link)player).IsDead)
            {
                player.useItem();
                projectile.addItem(projectile.Arrow, ((Link)player).CurrentLocation, ((Link)player).CurrentDirection);
            }
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}