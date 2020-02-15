namespace LoZClone
{
    public class CommandIdle : ICommand
    {
        IPlayer player;
        private static int priority = 0;
        public CommandIdle(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.idle();
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}