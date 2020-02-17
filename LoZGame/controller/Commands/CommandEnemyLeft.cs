namespace LoZClone
{
    public class CommandEnemyLeft : ICommand
    {
        readonly EnemyManager enemy;
        private static readonly int priority = -1;

        public CommandEnemyLeft(EnemyManager enemy)
        {
            this.enemy = enemy;
        }

        public void execute()
        {
            enemy.cycleLeft();
        }

        public int Priority => priority;
    }
}