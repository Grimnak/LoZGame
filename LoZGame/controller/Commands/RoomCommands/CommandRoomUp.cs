﻿namespace LoZClone
{
    /// <summary>
    /// Command for switching room to next one above.
    /// </summary>
    public class CommandRoomUp : ICommand
    {
        private RoomManager room;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandRoomUp"/> class.
        /// </summary>
        /// <param name="room">The room manager to execute a command on.</param>
        public CommandRoomUp(RoomManager room)
        {
            this.room = room;
        }

        /// <inheritdoc/>
        public int Priority => 0;

        /// <inheritdoc/>
        public void Execute()
        {
            this.room.MoveUp();
        }
    }
}
