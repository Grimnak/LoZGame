namespace LoZClone
{
    public class CommandD : ICommand
    {
        IPlayer player;
        public CommandD(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.moveRight();
        }
    }
}