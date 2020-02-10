namespace LoZClone
{
    public class CommandW : ICommand
    {
        IPlayer player;
        public CommandW(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.moveUp();
        }
    }
}