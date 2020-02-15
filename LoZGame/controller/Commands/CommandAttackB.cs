namespace LoZClone
{
    public class CommandAttackB : ICommand
    {
        IPlayer player;
        public CommandAttackB(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.attack();
        }
    }
}