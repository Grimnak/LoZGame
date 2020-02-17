namespace LoZClone
{
    public class CommandUp : ICommand
    {
        readonly IPlayer player;
        private static readonly int PriorityValue = 4;

        public CommandUp(IPlayer player)
        {
            this.player = player;
        }

        public void execute()
        {
            this.player.moveUp();
        }

        public int Priority => PriorityValue;
    }
}