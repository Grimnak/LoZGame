namespace LoZClone
{
    public class CommandEnemyRight : ICommand
    {
        //NpcManager? npc;
        private static int priority = -1;
        public CommandEnemyRight(/*NpcManager? npc*/)
        {
            //this.npc = npc;
        }
        public void execute()
        {
            //npc.CycleNpcRight();
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}