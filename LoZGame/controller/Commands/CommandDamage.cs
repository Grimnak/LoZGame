namespace LoZClone
{
    public class CommandDamage : ICommand
    {
        IPlayer player;
        private static int priority = -1;
        public CommandDamage(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.takeDamage();
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}