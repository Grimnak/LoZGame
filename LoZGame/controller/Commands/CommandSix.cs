namespace LoZClone
{
    public class CommandSix : ICommand
    {
        IPlayer player;
        public CommandSix(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            //player.useSecondaryItem();
        }
    }
}