namespace LoZClone
{
    public class CommandDamage : ICommand
    {
        IPlayer player;
        public CommandDamage(IPlayer player)
        {
            this.player = player;
        }
        public void execute()
        {
            player.takeDamage();
        }
    }
}