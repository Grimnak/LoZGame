namespace LoZClone
{
    /// <summary>
    /// Command that makes current enemy displayed cycle to the next enemy to the right.
    /// </summary>
    public class CommandEnemyRight : ICommand
    {
        private static readonly int PriorityValue = -1;


        /// <summary>
        /// Initializes a new instance of the <see cref="CommandEnemyRight"/> class.
        /// </summary>
        public CommandEnemyRight()
        {
        }

        /// <inheritdoc/>
        public int Priority => PriorityValue;

        /// <inheritdoc/>
        public void Execute()
        {
            EnemyManager.Instance.CycleRight();
        }
    }
}