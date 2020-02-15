namespace LoZClone
{
    public class CommandDown : ICommand
    {
        IPlayer player;
        public CommandDown(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.moveDown();
        }
    }
}