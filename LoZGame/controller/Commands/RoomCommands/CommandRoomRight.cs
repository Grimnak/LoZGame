﻿namespace LoZClone
{
    /// <summary>
    /// Command for switching room to next one above.
    /// </summary>
    public class CommandRoomRight : ICommand
    {
        private Dungeon room;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandRoomRight"/> class.
        /// </summary>
        /// <param name="room">The room manager to execute a command on.</param>
        public CommandRoomRight(Dungeon room)
        {
            this.room = room;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            this.room.MoveRight();
        }
    }
}
