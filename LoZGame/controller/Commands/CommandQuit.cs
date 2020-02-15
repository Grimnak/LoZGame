namespace LoZClone
{
    public class CommandQuit : ICommand
    {
        LoZGame game;
        public CommandQuit(LoZGame game)
        {
            this.game = game;
        }
        public void execute()
        {
            game.Exit();
        }
    }
}