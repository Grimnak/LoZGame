namespace LoZClone
{
    public class CommandEnemyRight : ICommand
    {
        readonly EnemyManager enemy;
        private static readonly int priority = -1;

        public CommandEnemyRight(EnemyManager enemy)
        {
            this.enemy = enemy;
        }

        public void execute()
        {
            this.enemy.cycleRight();
        }

        public int Priority => priority;
    }
}