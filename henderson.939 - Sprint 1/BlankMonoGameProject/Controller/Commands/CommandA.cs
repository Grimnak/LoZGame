namespace LoZClone
{
    public class CommandA : ICommand
    {
        IPlayer player;
        public CommandA(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.moveLeft();
        }
    }
}