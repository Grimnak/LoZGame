namespace LoZClone
{
    /// <summary>
    /// Command for switching room to next one above.
    /// </summary>
    public class CommandRoomUp : ICommand
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandRoomUp"/> class.
        /// </summary>
        public CommandRoomUp()
        {
        }

        /// <inheritdoc/>
        public void Execute()
        {
            LoZGame.Instance.Dungeon.MoveUp();
        }
    }
}
