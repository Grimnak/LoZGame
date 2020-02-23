﻿namespace LoZClone
{
    /// <summary>
    /// Command for switching room to next one below.
    /// </summary>
    public class CommandRoomDown : ICommand
    {
        private RoomManager room;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandRoomDown"/> class.
        /// </summary>
        /// <param name="room">The room manager to execute a command on.</param>
        public CommandRoomDown(RoomManager room)
        {
            this.room = room;
        }

        /// <inheritdoc/>
        public int Priority => 0;

        /// <inheritdoc/>
        public void Execute()
        {
            this.room.MoveDown();
        }
    }
}