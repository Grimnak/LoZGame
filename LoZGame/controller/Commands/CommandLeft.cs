namespace LoZClone
{
    public class CommandLeft : ICommand
    {
        IPlayer player;
        private static int priority = 1;
        public CommandLeft(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.moveLeft();
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}