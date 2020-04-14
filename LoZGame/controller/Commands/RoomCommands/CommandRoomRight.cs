namespace LoZClone
{
    /// <summary>
    /// Command for switching room to next one above.
    /// </summary>
    public class CommandRoomRight : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandRoomRight"/> class.
        /// </summary>
        public CommandRoomRight()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            if (LoZGame.Instance.GameState is PlayGameState)
            {
                LoZGame.Instance.Dungeon.MoveRight();
            }
        }
    }
}
