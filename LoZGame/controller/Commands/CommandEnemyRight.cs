namespace LoZClone
{
    public class CommandEnemyRight : ICommand
    {
        //NpcManager? npc;
        private static readonly int priority = -1;

        public CommandEnemyRight(/*NpcManager? npc*/)
        {
            //this.npc = npc;
        }

        public void execute()
        {
            //npc.CycleNpcRight();
        }

        public int Priority => priority;
    }
}