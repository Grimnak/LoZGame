namespace LoZClone
{
    public class CommandQ : ICommand
    {
        LoZGame game;
        public CommandQ(LoZGame game)
        {
            this.game = game;
        }
        public void execute()
        {
            game.Exit();
        }
    }
}