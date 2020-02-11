namespace LoZClone
{
    public class CommandE : ICommand
    {
        IPlayer player;
        public CommandE(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.takeDamage();
        }
    }
}