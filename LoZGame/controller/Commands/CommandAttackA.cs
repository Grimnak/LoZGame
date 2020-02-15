namespace LoZClone
{
    public class CommandAttackA : ICommand
    {
        IPlayer player;
        public CommandAttackA(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.attack();
        }
    }
}