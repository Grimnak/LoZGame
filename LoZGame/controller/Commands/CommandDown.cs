namespace LoZClone
{
    public class CommandDown : ICommand
    {
        IPlayer player;
        private static int priority = 2;
        public CommandDown(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.moveDown();
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}