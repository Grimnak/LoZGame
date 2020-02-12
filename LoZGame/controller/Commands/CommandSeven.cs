namespace LoZClone
{
    public class CommandSeven : ICommand
    {
        IPlayer player;
        public CommandSeven(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            //player.useSecondaryItem();
        }
    }
}