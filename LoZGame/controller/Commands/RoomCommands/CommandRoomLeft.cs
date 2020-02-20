namespace LoZClone
{
    /// <summary>
    /// Command for switching room to next one left.
    /// </summary>
    public class CommandRoomLeft : ICommand
    {
        private Dungeon room;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandRoomLeft"/> class.
        /// </summary>
        /// <param name="room">The room manager to execute a command on.</param>
        public CommandRoomLeft(Dungeon room)
        {
            this.room = room;
        }

        /// <inheritdoc/>
        public int Priority => 0;

        /// <inheritdoc/>
        public void Execute()
        {
            this.room.MoveLeft();
        }
    }
}
