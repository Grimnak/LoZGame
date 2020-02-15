namespace LoZClone
{
    public class CommandAttackA : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        private static int priority = 6;
        public CommandAttackA(IPlayer player, ProjectileManager projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }
        public void execute()
        {
            if (!((Link)player).IsDead)
            {
                player.attack();
                projectile.addItem(projectile.Swordbeam, (Link)player);
            }
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}