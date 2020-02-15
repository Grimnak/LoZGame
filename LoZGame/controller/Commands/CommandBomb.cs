namespace LoZClone
{
    public class CommandBomb : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        private static int priority = 5;
        public CommandBomb(IPlayer player,ProjectileManager projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }
        public void execute()
        {
            player.useItem();
            projectile.addItem(projectile.Bomb,((Link)player).CurrentLocation,((Link)player).CurrentDirection);
            
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}