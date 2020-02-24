namespace LoZClone
{
    /// <summary>
    /// Command that makes current enemy displayed cycle to the next enemy to the left.
    /// </summary>
    public class CommandEnemyLeft : ICommand
    {
        private static readonly int PriorityValue = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandEnemyLeft"/> class.
        /// </summary>
        public CommandEnemyLeft()
        {
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            EnemyManager.Instance.CycleLeft();
        }
    }
}