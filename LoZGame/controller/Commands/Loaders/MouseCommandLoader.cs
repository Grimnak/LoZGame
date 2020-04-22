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
        public MouseCommandLoader()
        {
            commandRoomUp = new CommandRoomUp();
            commandRoomDown = new CommandRoomDown();
            commandRoomLeft = new CommandRoomLeft();
            commandRoomRight = new CommandRoomRight();
        }

        /// <summary>
        /// Gets the command for moving the room up.
        /// </summary>
        public CommandRoomUp GetCommandRoomUp
        {
            get { return commandRoomUp; }
        }

        /// <summary>
        /// Gets the command for moving the room down.
        /// </summary>
        public CommandRoomDown GetCommandRoomDown
        {
            get { return commandRoomDown; }
        }

        /// <summary>
        /// Gets the command for moving the room left.
        /// </summary>
        public CommandRoomLeft GetCommandRoomLeft
        {
            get { return commandRoomLeft; }
        }

        /// <summary>
        /// Gets the command for moving the room right.
        /// </summary>
        public CommandRoomRight GetCommandRoomRight
        {
            get { return commandRoomRight; }
        }
    }
}
