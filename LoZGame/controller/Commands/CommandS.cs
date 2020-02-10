namespace LoZClone
{
    public class CommandS : ICommand
    {
        IPlayer player;
        public CommandS(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.moveDown();
        }
    }
}