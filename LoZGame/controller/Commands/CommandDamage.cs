namespace LoZClone
{
    public class CommandDamage : ICommand
    {
        readonly IPlayer player;
        private static readonly int priority = -1;

        public CommandDamage(IPlayer player)
        {
            this.player = player;
        }

        public void execute()
        {
            this.player.takeDamage();
        }

        public int Priority => priority;
    }
}