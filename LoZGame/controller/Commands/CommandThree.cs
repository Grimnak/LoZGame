namespace LoZClone
{
    public class CommandThree : ICommand
    {
        IPlayer player;
        public CommandThree(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            //player.useThirdItem();
        }
    }
}