namespace LoZClone
{
    public class CommandUp : ICommand
    {
        IPlayer player;
        private static int priority = 4;
        public CommandUp(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.moveUp();
        }

        public int Priority
        {
            get { return priority; }
        }
    }
}