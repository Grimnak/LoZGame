namespace LoZClone
{
    public class CommandR : ICommand
    {
        LoZGame game;
        public CommandR(LoZGame game)
        {
            this.game = game;
        }
        public void execute()
        {
            //game.Reset();
        }
    }
}