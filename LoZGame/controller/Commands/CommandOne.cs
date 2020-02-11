namespace LoZClone
{
    public class CommandOne : ICommand
    {
        IPlayer player;
        public CommandOne(IPlayer player/*item*/)
        {
            this.player = player;
        }
        public void execute()
        {
           
            //player.useItemAnimation2();
        }
    }
}