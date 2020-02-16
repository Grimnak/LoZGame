namespace LoZClone
{
    public class CommandAttackB : ICommand
    {
        IPlayer player;
        ProjectileManager projectile;
        private static int priority = 7;
        public CommandAttackB(IPlayer player, ProjectileManager projectile)
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