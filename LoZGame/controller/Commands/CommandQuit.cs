namespace LoZClone
{
    public class CommandQuit : ICommand
    {
        readonly LoZGame game;
        private static readonly int priority = -1;

        public CommandQuit(LoZGame game)
        {
            this.game = game;
        }

        public void execute()
        {
            this.game.Exit();
        }

        public int Priority => priority;
    }
}