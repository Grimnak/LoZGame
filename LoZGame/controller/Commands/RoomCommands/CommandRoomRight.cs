namespace LoZClone
{
    /// <summary>
    /// Command for switching room to next one above.
    /// </summary>
    public class CommandRoomRight : ICommand
    {
        private RoomManager room;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandRoomRight"/> class.
        /// </summary>
        /// <param name="room">The room manager to execute a command on.</param>
        public CommandRoomRight(RoomManager room)
        {
            this.room = room;
        }

        /// <inheritdoc/>
        public int Priority => 0;

        /// <inheritdoc/>
        public void Execute()
        {
            this.room.MoveRight();
        }
    }
}
