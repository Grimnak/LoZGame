namespace LoZClone
{
    public class CommandN : ICommand
    {
        IPlayer player;
        public CommandN(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.attack();
        }
    }
}