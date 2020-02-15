namespace LoZClone
{
    public class CommandQuit : ICommand
    {
        LoZGame game;
        private static int priority = -1;
        public CommandQuit(LoZGame game)
        {
            this.game = game;
        }
        public void execute()
        {
            game.Exit();
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}