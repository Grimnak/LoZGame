namespace LoZGame
{
    /// <summary>
    /// Command interface.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Gets priority value of the command.
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// Executes the command.
        /// </summary>
        void Execute();
    }
}