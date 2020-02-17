namespace LoZClone
{
    public class CommandIdle : ICommand
    {
        readonly IPlayer player;
        private static readonly int priority = 0;

        public CommandIdle(IPlayer player)
        {
            this.player = player;
        }

        public void execute()
        {
            this.player.idle();
        }

        public int Priority => priority;
    }
}