namespace LoZClone
{
    public class CommandFive : ICommand
    {
        IPlayer player;
        public CommandFive(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            //player.useSecondaryItem();
        }
    }
}