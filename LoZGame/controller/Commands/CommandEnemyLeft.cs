namespace LoZClone
{
    public class CommandEnemyLeft : ICommand
    {
        //NpcManager? npc;
        private static int priority = -1;
        public CommandEnemyLeft(/*NpcManager? npc*/)
        {
            //this.npc = npc;
        }
        public void execute()
        {
            //npc.CycleNpcLeft();
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}