namespace LoZClone
{
    /// <summary>
    /// A dungeon room and all its necessary info.
    /// </summary>
    public class Room
    {
        private bool exists;

        /// <summary>
        /// Gets a value indicating whether the room contains anything.
        /// </summary>
        public bool Exists
        {
            get { return this.exists; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        public Room()
        {
        }
    }
}
