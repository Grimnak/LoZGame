namespace LoZClone
{
    public class CommandUp : ICommand
    {
        readonly IPlayer player;
        private static readonly int priority = 4;

        public CommandUp(IPlayer player)
        {
            this.player = player;
        }

        public void execute()
        {
            this.player.moveUp();
        }

        public int Priority => priority;
    }
}