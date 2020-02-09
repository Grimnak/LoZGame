namespace LoZClone
{
    public class CommandOne : ICommand
    {
        IPlayer player;
        public CommandOne(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            //player.usePrimaryItem();
        }
    }
}