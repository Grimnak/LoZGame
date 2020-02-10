namespace LoZClone
{
    public class CommandFour : ICommand
    {
        IPlayer player;
        public CommandFour(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            //player.useSecondaryItem();
        }
    }
}