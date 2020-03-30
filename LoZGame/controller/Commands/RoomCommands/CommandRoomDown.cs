namespace LoZClone
{
    /// <summary>
    /// Command for switching room to next one below.
    /// </summary>
    public class CommandRoomDown : ICommand
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandRoomDown"/> class.
        /// </summary>
        public CommandRoomDown()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            LoZGame.Instance.Dungeon.MoveDown();
        }
    }
}
