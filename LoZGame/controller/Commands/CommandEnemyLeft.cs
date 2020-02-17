namespace LoZClone
{
    public class CommandEnemyLeft : ICommand
    {
        //NpcManager? npc;
        private static readonly int priority = -1;

        public CommandEnemyLeft(/*NpcManager? npc*/)
        {
            //this.npc = npc;
        }

        public void execute()
        {
            //npc.CycleNpcLeft();
        }

        public int Priority => priority;
    }
}