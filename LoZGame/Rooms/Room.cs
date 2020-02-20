using LoZGame.Interfaces;
using System.Collections.Generic;

namespace LoZClone
{
    /// <summary>
    /// A dungeon room and all its necessary info.
    /// </summary>
    public class Room
    {
        private bool exists;
        private string border;
        private List<IEnemy> enemies;
        private List<ITile> tiles;
        private List<Door> doors;

        public struct Door
        {

            private string location;
            private string kind;

            public Door(string loc, string k)
            {
                this.location = loc;
                this.kind = k;
            }
        }

        /*
         * args:
         * ns => namespace of XML dungeon doc
         * ex => whether the room is null or not
         */
        public Room(string ns, bool ex)
        {
            this.exists = ex;
            this.border = ns;
        }

        /// <summary>
        /// Gets a value indicating whether the room contains anything.
        /// </summary>
        public bool Exists
        {
            get { return this.exists; }
        }

        /*
         * args:
         * x => tile X location
         * y => tile Y location
         * type => type/kind of enemy at X/Y
         */
        private void AddEnemy(int x, int y, string type)
        {
            switch (type)
            {
                // TODO
                case "Goriya":
                    break;
                default:
                    break;
            }
        }

        /*
         * args:
         * x => tile X location
         * y => tile Y location
         * type => type of tile
         * name => name of tile sprite
         */
        private void AddTile(int x, int y, string type, string name)
        {
            // TODO
            switch (type)
            {
                case "Movable":
                    break;

                case "Walkable":
                    break;

                default:
                    break;
            }
        }

        /*
         * args:
         * location => N/E/S/W
         * kind => which kind of door sprite
         */
        private void AddDoor(string location, string kind)
        {
            this.doors.Add(new Door(location, kind)); // appending a new Door (struct above) to a room object's list of doors
        }
    }
}
