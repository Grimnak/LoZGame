namespace LoZClone
{
    public class CommandRight : ICommand
    {
        readonly IPlayer player;
        private static readonly int priority = 3;

        public CommandRight(IPlayer player)
        {
            this.player = player;
        }

        public void execute()
        {
            this.player.moveRight();
        }

        public int Priority => priority;
    }
}