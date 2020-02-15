namespace LoZClone
{
    public class CommandAttackB : ICommand
    {
        IPlayer player;
        private static int priority = 6;
        public CommandAttackB(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.attack();
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}