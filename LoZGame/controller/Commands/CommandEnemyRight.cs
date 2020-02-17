namespace LoZClone
{
    public class CommandEnemyRight : ICommand
    {
        private static readonly int PriorityValue = -1;
        private readonly EnemyManager enemy;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandEnemyRight"/> class.
        /// </summary>
        /// <param name="enemy">Enemy manager to execute a command on.</param>
        public CommandEnemyRight(EnemyManager enemy)
        {
            this.enemy = enemy;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            this.enemy.cycleRight();
        }
    }
}