namespace LoZClone
{
    public class CommandEnemyLeft : ICommand
    {
        private static readonly int PriorityValue = -1;
        private readonly EnemyManager enemy;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandEnemyLeft"/> class.
        /// </summary>
        /// <param name="enemy">Enemy to execute a command on.</param>
        public CommandEnemyLeft(EnemyManager enemy)
        {
            this.enemy = enemy;
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            this.enemy.cycleLeft();
        }
    }
}