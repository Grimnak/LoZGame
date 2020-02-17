namespace LoZClone
{
    public class CommandDown : ICommand
    {
        readonly IPlayer player;
        private static readonly int PriorityValue = 2;

        public CommandDown(IPlayer player)
        {
            this.player = player;
        }

        public void execute()
        {
            this.player.moveDown();
        }

        public int Priority => PriorityValue;
    }
}