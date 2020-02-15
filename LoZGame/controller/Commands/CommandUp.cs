namespace LoZClone
{
    public class CommandUp : ICommand
    {
        IPlayer player;
        public CommandUp(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.moveUp();
        }
    }
}