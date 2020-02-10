namespace LoZClone
{
    public class CommandTwo : ICommand
    {
        IPlayer player;
        public CommandTwo(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            //player.useSecondaryItem();
        }
    }
}