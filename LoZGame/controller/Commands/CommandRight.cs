namespace LoZClone
{
    public class CommandRight : ICommand
    {
        IPlayer player;
        public CommandRight(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.moveRight();
        }
    }
}