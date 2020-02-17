namespace LoZClone
{
    public class CommandLeft : ICommand
    {
        readonly IPlayer player;
        private static readonly int PriorityValue = 1;

        public CommandLeft(IPlayer player)
        {
            this.player = player;
        }

        public void execute()
        {
            this.player.moveLeft();
        }

        public int Priority => PriorityValue;
    }
}