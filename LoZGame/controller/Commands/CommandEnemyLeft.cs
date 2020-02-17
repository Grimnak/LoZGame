namespace LoZClone
{
    public class CommandEnemyLeft : ICommand
    {
        readonly EnemyManager enemy;
        private static readonly int PriorityValue = -1;

        public CommandEnemyLeft(EnemyManager enemy)
        {
            this.enemy = enemy;
        }

        public void execute()
        {
            this.enemy.cycleLeft();
        }

        public int Priority => PriorityValue;
    }
}