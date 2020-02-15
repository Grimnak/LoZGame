namespace LoZClone
{
    public class CommandRight : ICommand
    {
        IPlayer player;
        private static int priority = 3;
        public CommandRight(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.moveRight();
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}