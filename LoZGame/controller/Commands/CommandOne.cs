namespace LoZClone
{
    public class CommandOne : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        public CommandOne(IPlayer player,ProjectileManager projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }
        public void execute()
        {

            //player.useItem();
            projectile.addItem(projectile.Bomb,((Link)player).CurrentLocation,((Link)player).CurrentDirection);
            
        }
    }
}