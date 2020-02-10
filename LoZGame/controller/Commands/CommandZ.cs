namespace LoZClone
{
    public class CommandZ : ICommand
    {
        IPlayer player;
        public CommandZ(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.attack();
        }
    }
}