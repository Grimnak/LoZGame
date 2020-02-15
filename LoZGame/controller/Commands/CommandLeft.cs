namespace LoZClone
{
    public class CommandLeft : ICommand
    {
        IPlayer player;
        public CommandLeft(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.moveLeft();
        }
    }
}