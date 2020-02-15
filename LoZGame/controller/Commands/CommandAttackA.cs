namespace LoZClone
{
    public class CommandAttackA : ICommand
    {
        IPlayer player;
        private static int priority = 6;
        public CommandAttackA(IPlayer player)
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