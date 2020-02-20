namespace LoZClone
{
    /// <summary>
    /// Command loader for mouse commands.
    /// </summary>
    public class MouseCommandLoader
    {
        // Dungeon room;
        private CommandRoomUp commandRoomUp;
        private CommandRoomDown commandRoomDown;
        private CommandRoomLeft commandRoomLeft;
        private CommandRoomRight commandRoomRight;

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseCommandLoader"/> class.
        /// </summary>
        public MouseCommandLoader(Dungeon room)
        {
            // this.room = room;
            this.commandRoomUp = new CommandRoomUp(room);
            this.commandRoomDown = new CommandRoomDown(room);
            this.commandRoomLeft = new CommandRoomLeft(room);
            this.commandRoomRight = new CommandRoomRight(room);
        }

        /// <summary>
        /// Gets the command for moving the room up.
        /// </summary>
        public CommandRoomUp GetCommandRoomUp
        {
            get { return this.commandRoomUp; }
        }

        /// <summary>
        /// Gets the command for moving the room down.
        /// </summary>
        public CommandRoomDown GetCommandRoomDown
        {
            get { return this.commandRoomDown; }
        }

        /// <summary>
        /// Gets the command for moving the room left.
        /// </summary>
        public CommandRoomLeft GetCommandRoomLeft
        {
            get { return this.commandRoomLeft; }
        }

        /// <summary>
        /// Gets the command for moving the room right.
        /// </summary>
        public CommandRoomRight GetCommandRoomRight
        {
            get { return this.commandRoomRight; }
        }
    }
}
