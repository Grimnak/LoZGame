namespace LoZClone
{
    /// <summary>
    /// Command loader for mouse commands.
    /// </summary>
    public class MouseCommandLoader
    {
        private CommandRoomUp commandRoomUp;
        private CommandRoomDown commandRoomDown;
        private CommandRoomLeft commandRoomLeft;
        private CommandRoomRight commandRoomRight;

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseCommandLoader"/> class.
        /// </summary>
        /// <param name="room">Dungeon to execute the command on.</param>
        public MouseCommandLoader()
        {
            this.commandRoomUp = new CommandRoomUp();
            this.commandRoomDown = new CommandRoomDown();
            this.commandRoomLeft = new CommandRoomLeft();
            this.commandRoomRight = new CommandRoomRight();
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
