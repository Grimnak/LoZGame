namespace LoZClone
{
    public class CommandIdle : ICommand
    {
        IPlayer player;
        public CommandIdle(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.idle();
        }
    }
}